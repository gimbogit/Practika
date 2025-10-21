using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using NAudio.Midi;

namespace _7._1
{
    public partial class Form1 : Form
    {
        private HashSet<Keys> pressedKeys = new HashSet<Keys>();

        private MidiOut midiOut;
        // offset в полутонах относительно C (0..12)
        private Dictionary<Keys, (int offset, Button keyButton, Button indicator)> keyMap;
        private int currentInstrument = 0;
        private int volume = 100;
        private int octave = 4; // по умолчанию C4

        public Form1()
        {
            InitializeComponent();

            // Подпишем загрузку формы (на случай, если в Designer это не сделано)
            this.Load += Form1_Load;

            // Безопасная инициализация MIDI-порта (если нет устройств — показываем сообщение)
            try
            {
                if (MidiOut.NumberOfDevices > 0)
                {
                    midiOut = new MidiOut(0);
                }
                else
                {
                    MessageBox.Show("MIDI-устройства не обнаружены. Звука может не быть.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    midiOut = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при инициализации MIDI: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                midiOut = null;
            }

            KeyPreview = true;

            // Настройка TrackBar (громкость)
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 127;
            trackBar1.Value = volume;
            trackBar1.ValueChanged += TrackBar1_ValueChanged;

            // Настройка NumericUpDown (октава)
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 8;
            numericUpDown1.Value = octave;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;

            // Подписка на изменение выбранного инструмента
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            // Привязка клавиш: верхний ряд клавиатуры (Ё / 1 / 2 / ... / - / =)
            // offset — полутоны от C
            keyMap = new Dictionary<Keys, (int, Button, Button)>
            {
                { Keys.Oem3,      (0,  button1,  button9)  }, // Ё -> C
                { Keys.D1,        (1,  button2,  button10) }, // 1 -> C#
                { Keys.D2,        (2,  button3,  button11) }, // 2 -> D
                { Keys.D3,        (3,  button4,  button12) }, // 3 -> D#
                { Keys.D4,        (4,  button5,  button13) }, // 4 -> E
                { Keys.D5,        (5,  button6,  button14) }, // 5 -> F
                { Keys.D6,        (6,  button7,  button15) }, // 6 -> F#
                { Keys.D7,        (7,  button8,  button16) }, // 7 -> G
                { Keys.D8,        (8,  button22, button31) }, // 8 -> G#
                { Keys.D9,        (9,  button21, button30) }, // 9 -> A
                { Keys.D0,        (10, button20, button29) }, // 0 -> A#
                { Keys.OemMinus,  (11, button19, button28) }, // - -> B
                { Keys.Oemplus,   (12, button18, button27) }  // = -> C (на октаву выше)
            };

            // Подписка на клавиши
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Сделаем кликабельными кнопки мышью — чтобы по клику тоже звучало
            HookButtonMouseEvents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заполняем ComboBox именами инструментов (General MIDI)
            var instruments = new Dictionary<int, string>()
            {
                { 0, "Acoustic Grand Piano" },
                { 1, "Bright Acoustic Piano" },
                { 2, "Electric Grand Piano" },
                { 3, "Honky-Tonk Piano" },
                { 4, "Electric Piano 1" },
                { 5, "Electric Piano 2" },
                { 6, "Harpsichord" },
                { 7, "Clavinet" },
                { 8, "Celesta" },
                { 9, "Glockenspiel" },
                { 10, "Music Box" },
                { 11, "Vibraphone" },
                { 12, "Marimba" },
                { 13, "Xylophone" },
                { 14, "Tubular Bells" },
                { 15, "Dulcimer" },
                { 16, "Drawbar Organ" },
                { 17, "Percussive Organ" },
                { 18, "Rock Organ" },
                { 19, "Church Organ" },
                { 20, "Reed Organ" },
                { 21, "Accordion" },
                { 22, "Harmonica" },
                { 23, "Tango Accordion" },
                { 24, "Acoustic Guitar (nylon)" },
                { 25, "Acoustic Guitar (steel)" },
                { 26, "Electric Guitar (jazz)" },
                { 27, "Electric Guitar (clean)" },
                { 28, "Electric Guitar (muted)" },
                { 29, "Overdriven Guitar" },
                { 30, "Distortion Guitar" },
                { 31, "Guitar Harmonics" },
                { 32, "Acoustic Bass" },
                { 33, "Electric Bass (finger)" },
                { 34, "Electric Bass (pick)" },
                { 35, "Fretless Bass" },
                { 36, "Slap Bass 1" },
                { 37, "Slap Bass 2" },
                { 38, "Synth Bass 1" },
                { 39, "Synth Bass 2" },
                { 40, "Violin" },
                { 41, "Viola" },
                { 42, "Cello" },
                { 43, "Contrabass" },
                { 44, "Tremolo Strings" },
                { 45, "Pizzicato Strings" },
                { 46, "Orchestral Harp" },
                { 47, "Timpani" },
                { 48, "String Ensemble 1" },
                { 49, "String Ensemble 2" },
                { 50, "SynthStrings 1" },
                { 51, "SynthStrings 2" },
                { 52, "Choir Aahs" },
                { 53, "Voice Oohs" },
                { 54, "Synth Voice" },
                { 55, "Orchestra Hit" },
                { 56, "Trumpet" },
                { 57, "Trombone" },
                { 58, "Tuba" },
                { 59, "Muted Trumpet" },
                { 60, "French Horn" },
                { 61, "Brass Section" },
                { 62, "SynthBrass 1" },
                { 63, "SynthBrass 2" },
                { 64, "Soprano Sax" },
                { 65, "Alto Sax" },
                { 66, "Tenor Sax" },
                { 67, "Baritone Sax" },
                { 68, "Oboe" },
                { 69, "English Horn" },
                { 70, "Bassoon" },
                { 71, "Clarinet" },
                { 72, "Piccolo" },
                { 73, "Flute" },
                { 74, "Recorder" },
                { 75, "Pan Flute" },
                { 76, "Blown Bottle" },
                { 77, "Shakuhachi" },
                { 78, "Whistle" },
                { 79, "Ocarina" },
                { 80, "Square Lead" },
                { 81, "Saw Lead" },
                { 82, "Calliope Lead" },
                { 83, "Chiff Lead" },
                { 84, "Charang Lead" },
                { 85, "Voice Lead" },
                { 86, "Fifths Lead" },
                { 87, "Bass + Lead" },
                { 88, "New Age Pad" },
                { 89, "Warm Pad" },
                { 90, "Polysynth Pad" },
                { 91, "Choir Pad" },
                { 92, "Bowed Pad" },
                { 93, "Metallic Pad" },
                { 94, "Halo Pad" },
                { 95, "Sweep Pad" },
                { 96, "FX Rain" },
                { 97, "FX Soundtrack" },
                { 98, "FX Crystal" },
                { 99, "FX Atmosphere" },
                { 100, "FX Brightness" },
                { 101, "FX Goblins" },
                { 102, "FX Echoes" },
                { 103, "FX Sci-Fi" },
                { 104, "Sitar" },
                { 105, "Banjo" },
                { 106, "Shamisen" },
                { 107, "Koto" },
                { 108, "Kalimba" },
                { 109, "Bagpipe" },
                { 110, "Fiddle" },
                { 111, "Shanai" },
                { 112, "Tinkle Bell" },
                { 113, "Agogo" },
                { 114, "Steel Drums" },
                { 115, "Woodblock" },
                { 116, "Taiko Drum" },
                { 117, "Melodic Tom" },
                { 118, "Synth Drum" },
                { 119, "Reverse Cymbal" },
                { 120, "Guitar Fret Noise" },
                { 121, "Breath Noise" },
                { 122, "Seashore" },
                { 123, "Bird Tweet" },
                { 124, "Telephone Ring" },
                { 125, "Helicopter" },
                { 126, "Applause" },
                { 127, "Gunshot" }
            };

            comboBox1.DataSource = new BindingSource(instruments, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedIndex = 0;

            // Установим начальный инструмент (если есть MIDI)
            if (midiOut != null)
            {
                if (comboBox1.SelectedValue is int programNumber)
                    midiOut.Send(MidiMessage.ChangePatch(programNumber, 1).RawData);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is int instrument)
            {
                currentInstrument = instrument;
                if (midiOut != null)
                    midiOut.Send(MidiMessage.ChangePatch(currentInstrument, 1).RawData);
            }
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            volume = trackBar1.Value;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            octave = (int)numericUpDown1.Value;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyMap.ContainsKey(e.KeyCode))
            {
                // если клавиша уже зажата — выходим
                if (pressedKeys.Contains(e.KeyCode))
                    return;

                pressedKeys.Add(e.KeyCode);

                var (offset, keyButton, indicator) = keyMap[e.KeyCode];
                int note = GetMidiNoteForC(octave) + offset;

                midiOut.Send(MidiMessage.StartNote(note, volume, 1).RawData);
                indicator.BackColor = Color.LimeGreen;
                keyButton.BackColor = Color.LightGreen;
            }
        }


        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyMap.ContainsKey(e.KeyCode))
            {
                // если клавиша была нажата — убираем её из множества
                if (pressedKeys.Contains(e.KeyCode))
                    pressedKeys.Remove(e.KeyCode);

                var (offset, keyButton, indicator) = keyMap[e.KeyCode];
                int note = GetMidiNoteForC(octave) + offset;

                midiOut.Send(MidiMessage.StopNote(note, 0, 1).RawData);
                indicator.BackColor = SystemColors.Control;
                keyButton.BackColor = SystemColors.Control;
            }
        }


        // Возвращает MIDI-номер ноты C в выбранной октаве. (C0 = 12, C4 = 60)
        private int GetMidiNoteForC(int octaveNumber)
        {
            return 12 * (octaveNumber + 1);
        }

        // Подключаем обработчики мыши для всех "больших" клавиш, чтобы по клику тоже звучало
        private void HookButtonMouseEvents()
        {
            var buttons = new List<Button>
    {
        button1, button2, button3, button4, button5, button6, button7, button8,
        button18, button19, button20, button21, button22
    };

            foreach (var b in buttons)
            {
                b.MouseDown += (s, ev) =>
                {
                    var btn = s as Button;
                    var mapping = FindMappingByButton(btn);
                    if (mapping != null)
                    {
                        var data = mapping.Value.Value; // 👈 достаём tuple из KeyValuePair
                        int note = GetMidiNoteForC(octave) + data.offset;
                        midiOut?.Send(MidiMessage.StartNote(note, volume, 1).RawData);
                        data.keyButton.BackColor = Color.LightGreen;
                        data.indicator.BackColor = Color.LimeGreen;
                    }
                };

                b.MouseUp += (s, ev) =>
                {
                    var btn = s as Button;
                    var mapping = FindMappingByButton(btn);
                    if (mapping != null)
                    {
                        var data = mapping.Value.Value; // 👈 достаём tuple из KeyValuePair
                        int note = GetMidiNoteForC(octave) + data.offset;
                        midiOut?.Send(MidiMessage.StopNote(note, 0, 1).RawData);
                        data.keyButton.BackColor = SystemColors.Control;
                        data.indicator.BackColor = SystemColors.Control;
                    }
                };
            }
        }


        // Найти mapping по Button (по keyButton)
        private KeyValuePair<Keys, (int offset, Button keyButton, Button indicator)>? FindMappingByButton(Button b)
        {
            foreach (var kv in keyMap)
            {
                if (kv.Value.keyButton == b) return kv;
            }
            return null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            midiOut?.Dispose();
            base.OnFormClosing(e);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
