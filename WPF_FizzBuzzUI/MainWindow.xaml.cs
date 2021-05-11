using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using FizzBuzzLibrary;

namespace WPF_FizzBuzzUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<string> fizzBuzzList = new BindingList<string>();
        BindingList<(int, string)> rulesList = new BindingList<(int, string)>();
        bool isValidInt = false;

        public MainWindow()
        {
            InitializeComponent();
            PopulateRulesListBox();

            fizzBuzzListBox.ItemsSource = fizzBuzzList;
            rulesListBox.ItemsSource = rulesList;
        }

        private void PopulateRulesListBox()
        {
            var rules = FizzBuzz.FizzBuzzRules;

            rulesList.Clear();

            foreach (var r in rules)
            {
                rulesList.Add(r);
            }
        }
        private void ClearTextBoxDefaultText_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;
            tb.Text = string.Empty;
        }

        private void RunFizzBuzz_Click(object sender, RoutedEventArgs e)
        {
            bool isValidInt = false;

            isValidInt = int.TryParse(startIndexText.Text, out int startIndex);
            isValidInt = int.TryParse(endIndexText.Text, out int endIndex);

            if (isValidInt == true)
            {
                CreateFizzBuzzList(startIndex, endIndex);
            }
            else if (isValidInt == false)
            {
                MessageBox.Show(
                    $"Invalid index entry ({startIndex},{endIndex}). Please enter valid Start and End index.", "Warning");
            }
        }

        private void CreateFizzBuzzList(int startIndex, int endIndex)
        {
            List<string> fizzBuzz = FizzBuzz.RunElaborateFizzBuzz(startIndex, endIndex);

            fizzBuzzList.Clear();

            foreach (var f in fizzBuzz)
            {
                fizzBuzzList.Add(f);
            }
        }

        private void ResetTextBoxDefaultText(TextBox textBoxText1, TextBox textBoxText2)
        {
            textBoxText1.Text = textBoxText1.Tag.ToString();
            textBoxText2.Text = textBoxText2.Tag.ToString();
        }

        private void AddFizzBuzzRule_Click(object sender, RoutedEventArgs e)
        {
            isValidInt = int.TryParse(addIntegerText.Text, out int addInteger);
            String addString = addStringText.Text;

            (int index, string value) rule = (index: addInteger, value: addString);
            
            bool ruleExists = ListContainsFizzBuzzRule(rule);

            if (ruleExists == true)
            {
                MessageBox.Show($"Duplicate rule ({addInteger},{addString}).  Please enter a unique rule.", "Warning");
            }
            else if (isValidInt == true && addString != "Enter String" && !String.IsNullOrWhiteSpace(addString))
            {
                FizzBuzz.FizzBuzzRules.Add((addInteger, addString));

                PopulateRulesListBox();
            }
            else 
            {
                MessageBox.Show($"Invalid rule entry ({addInteger},{addString}).  Please enter a valid rule.", "Warning");
            }

            ResetTextBoxDefaultText(addIntegerText, addStringText);
        }

        private bool ListContainsFizzBuzzRule((int, string) rule)
        {
            return FizzBuzz.FizzBuzzRules.Contains(rule);
        }

        private void DeleteFizzBuzzRule_Click(object sender, RoutedEventArgs e)
        {
            isValidInt = int.TryParse(deleteIntegerText.Text, out int removeInteger);

            String removeString = deleteStringText.Text;

            (int index, string value) rule = (index: removeInteger, value: removeString);

            bool ruleExists = ListContainsFizzBuzzRule(rule);
           
            if (ruleExists == false)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Invalid rule entry ({removeInteger},{removeString}). Please enter a valid rule.", "Warning");
            }
            else if (ruleExists == true)
            {
                bool confirmDelete = ConfirmDeleteRule(removeInteger, removeString);

                if (confirmDelete == true)
                {
                    FizzBuzz.FizzBuzzRules.Remove((removeInteger, removeString));
                    PopulateRulesListBox();
                }
            }

            ResetTextBoxDefaultText(deleteIntegerText, deleteStringText);
        }

        private bool ConfirmDeleteRule(int removeInteger, string removeString)
        {
            bool output = true;

            MessageBoxResult result = MessageBox.Show(
            $"Do you want to delete rule ({removeInteger},{removeString})?", "Delete Confirmation", MessageBoxButton.YesNo);
            
            if (result == MessageBoxResult.Yes)
            {
                output = true;
            }
            else
            {
                output = false;
            }

            return output;
        }
    }
}
