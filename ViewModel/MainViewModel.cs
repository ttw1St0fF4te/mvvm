using mvvm.Model;
using mvvm.View;
using mvvm.ViewModel.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using vipief.ViewModel.Helpers;

namespace mvvm.ViewModel
{
    internal class MainViewModel : BindingHelper
    {
        #region Биндинг для команд
        public BindableCommand BinarySystem { get; set; }
        public BindableCommand OctalSystem { get; set; }
        public BindableCommand HexadecimalSystem {  get; set; }
        public BindableCommand Openhistory { get; set; }

        private string numberEntered;
        #endregion

        #region Свойства
        public string NumberEntered
        {
            get { return numberEntered; }
            set
            {
                numberEntered = value;
                OnPropertyChanged();
            }
        }

        private string generatedNumber;

        public string GeneratedNumber
        {
            get { return generatedNumber; }
            set
            {
                generatedNumber = value;
                OnPropertyChanged();
            }
        }

        public List<Number> numbers = new List<Number>();
        #endregion

        #region Функции
        public void toBinary()
        {
            string binary = "";
            if (!string.IsNullOrEmpty(NumberEntered))
            {
                for (int i = 0; i < NumberEntered.Length; i++)
                {
                    if (char.IsLetter(NumberEntered[i]))
                        return;
                }
                int num = (int)Convert.ToInt64(NumberEntered);
                if (num == 0)
                {
                    binary = "0";
                    return;
                }
                while (num > 0)
                {
                    int remainder = num % 2;
                    binary += Convert.ToString(remainder);
                    num /= 2;
                }
                string reversed = "";
                for (int i = binary.Length - 1; i >= 0; --i)
                {
                    reversed += binary[i];
                }
                GeneratedNumber = "Ответ: " + reversed;
                numbers.Add(new Number(reversed));

                string json = JsonConvert.SerializeObject(numbers);
                File.WriteAllTextAsync("Number.json", json);
            }
        }
        public void toOctal()
        {
            string octal = "";
            if (!string.IsNullOrEmpty(NumberEntered))
            {
                for (int i = 0; i < NumberEntered.Length; i++)
                {
                    if (char.IsLetter(NumberEntered[i]))
                        return;
                }
                int num = (int)Convert.ToInt64(NumberEntered);
                if (num == 0)
                {
                    octal = "0";
                    return;
                }
                while (num > 0)
                {
                    int remainder = num % 8;
                    octal += Convert.ToString(remainder);
                    num /= 8;
                }
                string reversed = "";
                for (int i = octal.Length - 1; i >= 0; --i)
                {
                    reversed += octal[i];
                }
                GeneratedNumber = "Ответ: " + reversed;
                numbers.Add(new Number(reversed));

                string json = JsonConvert.SerializeObject(numbers);
                File.WriteAllTextAsync("Number.json", json);
            }
        }
        public void toHexadecimal()
        {
            string hex = "";
            if (!string.IsNullOrEmpty(NumberEntered))
            {
                for (int i = 0; i < NumberEntered.Length; i++)
                {
                    if (char.IsLetter(NumberEntered[i]))
                        return;
                }
                int num = (int)Convert.ToInt64(NumberEntered);
                if (num == 0)
                {
                    hex = "0";
                    return;
                }
                int decimalValue;
                if (int.TryParse(NumberEntered, out decimalValue))
                {
                    hex = Convert.ToString(decimalValue, 16).ToUpper();
                }
                GeneratedNumber = "Ответ: " + hex;
                numbers.Add(new Number(hex));

                string json = JsonConvert.SerializeObject(numbers);
                File.WriteAllTextAsync("Number.json", json);
            }
        }

        public void OpenPage()
        {
            HistoryWindow historyWindow = new HistoryWindow();
            historyWindow.Show();
        }
        #endregion

        public MainViewModel() 
        {
            BinarySystem = new BindableCommand(_ => toBinary());
            OctalSystem = new BindableCommand(_ => toOctal());
            HexadecimalSystem = new BindableCommand(_ => toHexadecimal());
            Openhistory = new BindableCommand(_ => OpenPage());
        }
    }
}
