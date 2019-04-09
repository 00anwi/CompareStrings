using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        /// <summary>
        /// Checks the difference between two strings
        /// </summary>
        /// <returns>Number of Differnces</returns>
        private int CalculateDifferenceStrings(string String1, string String2)
        {
            ArrayList list = new ArrayList();
            ArrayList list2 = new ArrayList();
            bool StringsDiffLenght = false;
            int Result = 0;

            try
            {
                //Adds the index of all different characters between String2 and String1 to list
                for (int i = 0; i < String1.Length; ++i)
                {
                    if (i >= String2.Length)
                        list.Add(i);
                    else if (String1[i] != String2[i])
                        list.Add(i);
                }

                lblDiff.Text = list.Count.ToString();

                //Checks if String2 data is longer then String1
                //This is incase String2 have one or more characters somewhere in the string. 
                //Example 
                //String1=1234 and String=11234
                //We know from list that index 1, 2, 3 is wrong
                //But if we remove the string difference from the first wrong index=1
                //We get String2=1234 and no differences
                if (String2.Length > String1.Length)
                {
                    int[] indicesCheck = (int[])list.ToArray(typeof(int));
                    int StringLenghtDifference = String2.Length - String1.Length;  //Gets lenght differnce
                    string NewString2 = "";
                    if (list.Count == 0)
                    {
                        NewString2 = String2.Remove(String1.Length, StringLenghtDifference); //Removes characters from index of first fault and the character lenght difference between String1 and String2
                    }
                    else
                    {
                        NewString2 = String2.Remove(indicesCheck[0], StringLenghtDifference); //Removes characters from index of first fault and the character lenght difference between String1 and String2
                    }

                    //Adds the index of all different characters between NewString2 and String1 to list2
                    for (int i = 0; i < String1.Length; ++i)
                    {
                        if (i >= NewString2.Length)
                            list2.Add(i);
                        else if (String1[i] != NewString2[i])
                            list2.Add(i);
                    }

                    //This is for when string is different but not different lengths other wise it would send back 0 even if all characters are different
                    StringsDiffLenght = true;
                }
                else if (String1.Length > String2.Length)
                {
                    int[] indicesCheck = (int[])list.ToArray(typeof(int));
                    int StringLenghtDifference = String1.Length - String2.Length;  //Gets lenght differnce
                    string NewString2 = "";

                    NewString2 = ReturnXNbrOfQuestionMark(StringLenghtDifference) + String2;

                    //Adds the index of all different characters between NewString2 and String1 to list2
                    for (int i = 0; i < String1.Length; ++i)
                    {
                        if (i >= NewString2.Length)
                            list2.Add(i);
                        else if (String1[i] != NewString2[i])
                            list2.Add(i);
                    }

                    //This is for when string is different but not different lengths other wise it would send back 0 even if all characters are different
                    StringsDiffLenght = true;
                }


                int[] indices = (int[])list.ToArray(typeof(int));
                int[] indices2 = (int[])list2.ToArray(typeof(int));

                if (indices2.Count() < indices.Count() && StringsDiffLenght)
                {
                    //Counts how many indexed faults in list2 if character lenght is different and list2 countains less indexed faults
                    foreach (var indexes2 in list2)
                    {
                        ++Result;
                    }
                }
                else
                {
                    //Counts how many indexed faults in list
                    foreach (var indexes in list)
                    {
                        ++Result;
                    }
                }
            }
            catch (Exception ex)
            {
                return String1.Length;
            }

            return Result;
        }

        private string ReturnXNbrOfQuestionMark(int X)
        {
            string ReturnString = "";
            for (int i = 0; i < X; i++)
            {
                ReturnString += "?";
            }

            return ReturnString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = txtbString1.Text;
            string str2 = txtbString2.Text;

            lblDiffFault.Text = CalculateDifferenceStrings(str1, str2).ToString();
        }
    }
}
