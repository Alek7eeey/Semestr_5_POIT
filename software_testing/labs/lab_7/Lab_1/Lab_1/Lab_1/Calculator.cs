﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_1
{
    interface IMakeOperation
    {
        void MakeOpeartion(ref long currentSum,ref TextBox inputArea, ref bool plus, ref bool minus, ref bool del, ref bool mult, ref bool ost);
        void MakeOpeartionStr(ref long currentSum, string inputArea, ref bool plus, ref bool minus, ref bool del, ref bool mult, ref bool ost);
    }
    public class Calculator : IMakeOperation
    {
        public Calculator() { }
        public void MakeOpeartion(ref long currentSum, ref TextBox inputArea, ref bool plus, ref bool minus, ref bool del, ref bool mult, ref bool ost)
        {
            if(inputArea.Text == "")
            {
                throw new Exception("Ничего не введено!");
            }

            if (currentSum == 0)
            {
                currentSum += Convert.ToInt32(inputArea.Text);
            }

            else
            {
                if (plus)
                {
                    currentSum += Convert.ToInt32(inputArea.Text);
                    plus = false;
                }

                if (minus)
                {
                    currentSum -= Convert.ToInt32(inputArea.Text);
                    minus = false;
                }

                if (del)
                {
                    currentSum /= Convert.ToInt32(inputArea.Text);
                    del = false;
                }
                if (mult)
                {
                    currentSum *= Convert.ToInt32(inputArea.Text);
                    mult = false;
                }
                if (ost)
                {
                    currentSum %= Convert.ToInt32(inputArea.Text);
                    ost = false;
                }

            }
            inputArea.Text = null;
        }

        public void MakeOpeartionStr(ref long currentSum, string inputArea, ref bool plus, ref bool minus, ref bool del, ref bool mult, ref bool ost)
        {
            if (inputArea == "")
            {
                throw new Exception("Ничего не введено!");
            }

            if (currentSum == 0)
            {
                currentSum += Convert.ToInt32(inputArea);
            }

            else
            {
                if (plus)
                {
                    currentSum += Convert.ToInt32(inputArea);
                    plus = false;
                }

                if (minus)
                {
                    currentSum -= Convert.ToInt32(inputArea);
                    minus = false;
                }

                if (del)
                {
                    if(Convert.ToInt32(inputArea) == 0)
                    {
                        throw new Exception("division by zero");
                    }
                    currentSum /= Convert.ToInt32(inputArea);
                    del = false;
                }
                if (mult)
                {
                    currentSum *= Convert.ToInt32(inputArea);
                    mult = false;
                }
                if (ost)
                {
                    if (Convert.ToInt32(inputArea) == 0)
                    {
                        throw new Exception("division by zero");
                    }
                    currentSum %= Convert.ToInt32(inputArea);
                    ost = false;
                }

            }
        }
    }
}
