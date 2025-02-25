using System.Text;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string _charDer = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            _charDer = DerTextBox.Text.Trim();
            var s = Calcualte(CalculateTextBox.Text);
            CalculateTextBox.Text = s;
        }

        private string Calcualte(string text)
        {
            var arr = text.Split(" ").ToArray();
            int currentPriority = 0;
            int lastPrioprity = 0;
            Stack<string> numbers = new Stack<string>();
            Stack<string> operators = new Stack<string>();
            StringBuilder result = new StringBuilder();

            foreach (var item in arr)
            {
                if (item.Contains(_charDer))
                {
                    numbers.Push(item);
                }
                else
                {
                    switch (item)
                    {
                        case "(":
                            operators.Push(item);
                            currentPriority += 3;
                            break;
                        case ")":
                            var isFirst = true;

                            while (operators.Count > 0)
                            {
                                var oldOperator = operators.Pop();

                                if (oldOperator == "(")
                                {
                                    break;
                                }
                                if (isFirst)
                                {
                                    if (oldOperator == "+" || oldOperator == "-")
                                    {
                                        lastPrioprity -= 1;
                                    }
                                    else if (oldOperator == "*" || oldOperator == "/")
                                    {
                                        lastPrioprity -= 2;
                                    }

                                    isFirst = false;
                                }

                                

                                Result(oldOperator, numbers.Pop(), numbers.Pop(), result);
                            }
                            currentPriority -= 3;
                            lastPrioprity -= 3;
                            break;
                        case "+":
                        case "-":
                            if (numbers.Count != 0)
                            {
                                currentPriority += 1;

                                if (lastPrioprity < currentPriority)
                                {
                                    lastPrioprity = currentPriority;
                                    currentPriority -= 1;
                                    operators.Push(item);
                                }
                                else
                                {
                                    while (operators.Count > 0)
                                    {
                                        Result(operators.Pop(), numbers.Pop(), numbers.Pop(), result);
                                        currentPriority -= 1;
                                    }
                                    operators.Push(item);
                                }
                            }
                            else
                            {
                                lastPrioprity = currentPriority;
                                currentPriority -= 1;
                                operators.Push(item);
                            }
                            break;
                        case "*":
                        case "/":
                            if (numbers.Count != 0)
                            {
                                currentPriority += 2;

                                if (lastPrioprity < currentPriority)
                                {
                                    lastPrioprity = currentPriority;
                                    currentPriority -= 2;
                                    operators.Push(item);
                                }
                                else
                                {
                                    while (operators.Count > 0)
                                    {
                                        Result(operators.Pop(), numbers.Pop(), numbers.Pop(), result);
                                        currentPriority -= 2;
                                    }
                                    operators.Push(item);
                                }
                            }
                            else
                            {
                                lastPrioprity = currentPriority;
                                currentPriority -= 2;
                                operators.Push(item);
                            }
                            break;
                    }
                }
            }

            if (operators.Count == 0)
            {
                result.Append(GetDerivative(numbers.Pop()));
            }
            else
            {
                while (operators.Count > 0)
                {
                    if (numbers.Count > 2)
                    {
                        Result(operators.Pop(), numbers.Pop(), numbers.Pop(), result);
                    }
                    else if (numbers.Count == 1) 
                    {
                        result.Append(operators.Pop() + " " + GetDerivative(numbers.Pop()));
                    }
                }
            }



            return result.ToString();
        }


        private void Result(string oper, string x2, string x1, StringBuilder result)
        {
            switch (oper)
            {
                case "+":
                    result.Append(GetDerivative(x1) + "+ " + GetDerivative(x2));
                    break;
                case "-":
                    result.Append(GetDerivative(x1) + "- " + GetDerivative(x2));
                    break;
                case "*":
                    result.Append(GetDerivative(x1) + "* " + x2 + "+ " + x1 + "* " + GetDerivative(x2));
                    break;
                case "/":
                    result.Append($"{GetDerivative(x1)} * {x2} - {GetDerivative(x2)} * {x1} / {x2}**2");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string GetDerivative(string x)
        {
            StringBuilder result = new StringBuilder();

            if (x.Contains("**"))
            {
                var arr = x.Split("**").Select(x => x.Contains(_charDer) ? x.Replace(_charDer, "") : x)
                    .Where(_ => !string.IsNullOrEmpty(_)).ToArray();

                if (!x.StartsWith(_charDer))
                {
                    result.Append(int.Parse(arr[0]) * int.Parse(arr[1]) + _charDer);
                    
                    if (arr[1] != "2")
                    {
                        result.Append("**" + (int.Parse(arr[1]) - 1).ToString());
                    }
                }
                else
                {
                    result.Append(arr[0] + _charDer);

                    if (arr[0] != "2")
                    {
                        result.Append("**" + (int.Parse(arr[0]) - 1).ToString());
                    }
                }
            }

            else if (x.StartsWith("sin"))
            {
                var arr = x.Split('(', ')').ToArray();

                if (arr[1] == _charDer)
                {
                    result.Append($"cos({_charDer})");
                }
            }

            else if (x.StartsWith("cos"))
            {
                var arr = x.Split('(', ')').ToArray();

                if (arr[1] == _charDer)
                {
                    result.Append($"-sin({_charDer})");
                }
            }

            else if (x.Contains(_charDer))
            {
                var rep = x.Replace(_charDer, "");
                result.Append(rep);
            }

            return result.Append(" ").ToString();
        }
    }
}
