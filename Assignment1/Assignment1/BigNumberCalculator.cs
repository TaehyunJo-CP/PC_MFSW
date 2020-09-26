using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Assignment1
{
    namespace Assignment1
    {
        public class BigNumberCalculator
        {
            private readonly int mBitCount;
            private readonly EMode Mode;

            public BigNumberCalculator(int bitCount, EMode mode)
            {
                this.mBitCount = bitCount;
                this.Mode = mode;
            }


            public static string GetOnesComplementOrNull(string num)
            {
                NumberTypeChecker numberTypeChecker = new NumberTypeChecker(num);
                if (numberTypeChecker.NumberType == ENumberType.Binary)
                {
                    StringBuilder stringBuilder = new StringBuilder("0b");
                    foreach (char c in numberTypeChecker.NumberPart)
                    {
                        if (c == '0')
                        {
                            stringBuilder.Append('1');
                        }
                        else if (c == '1')
                        {
                            stringBuilder.Append('0');
                        }
                    }

                    return stringBuilder.ToString();
                }
                else
                {
                    return null;
                }

            }

            public static string GetTwosComplementOrNull(string num)
            {
                NumberTypeChecker numberTypeChecker = new NumberTypeChecker(num);
                if (numberTypeChecker.NumberType == ENumberType.Binary)
                {
                    StringBuilder stringBuilder = new StringBuilder("0b");
                    foreach (char c in numberTypeChecker.NumberPart)
                    {
                        if (c == '0')
                        {
                            stringBuilder.Append('1');
                        }
                        else if (c == '1')
                        {
                            stringBuilder.Append('0');
                        }
                    }

                    string result = stringBuilder.ToString();

                    int remainChars = result.Length;

                    for (int i = result.Length - 1; i >= 0; i--)
                    {
                        if (remainChars == 2)
                        {
                            break;
                        }

                        if (result[i] == '0')
                        {
                            stringBuilder[i] = '1';
                            break;
                        }
                        else if (result[i] == '1')
                        {
                            stringBuilder[i] = '0';
                        }

                        remainChars--;
                    }

                    return stringBuilder.ToString();
                }
                else
                {
                    return null;
                }
            }

            private static readonly Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string> {
                { '0', "0000" },
                { '1', "0001" },
                { '2', "0010" },
                { '3', "0011" },
                { '4', "0100" },
                { '5', "0101" },
                { '6', "0110" },
                { '7', "0111" },
                { '8', "1000" },
                { '9', "1001" },
                { 'a', "1010" },
                { 'b', "1011" },
                { 'c', "1100" },
                { 'd', "1101" },
                { 'e', "1110" },
                { 'f', "1111" }
            };

            public static string ToBinaryOrNull(string num)
            {
                NumberTypeChecker numberTypeChecker = new NumberTypeChecker(num);
                if (numberTypeChecker.NumberType == ENumberType.Binary)
                {
                    return num;
                }
                else if (numberTypeChecker.NumberType == ENumberType.Hex)
                {
                    StringBuilder stringBuilder = new StringBuilder("0b");

                    string numberPart = numberTypeChecker.NumberPart;
                    int numberPartLength = numberPart.Length;
                    foreach (char c in numberPart)
                    {
                        stringBuilder.Append(hexCharacterToBinary[char.ToLower(c)]);
                    }

                    return stringBuilder.ToString();
                }
                else if (numberTypeChecker.NumberType == ENumberType.Decimal)
                {
                    StringBuilder sb = new StringBuilder();

                    string numberPart = numberTypeChecker.NumberPart;
                    bool isDone = false;

                    string targetNum = numberPart;
                    while (!isDone)
                    {
                        StringDivider sd = new StringDivider(targetNum, 2);
                        if (sd.Q == "0")
                        {
                            sb.Append(sd.R);
                            isDone = true;
                        }
                        else
                        {
                            sb.Append(sd.R);
                            targetNum = sd.Q;
                        }
                    }

                    string toReverse = sb.ToString();
                    StringBuilder resultSb = new StringBuilder("0b");

                    for (int i = toReverse.Length - 1; i >= 0; i--)
                    {
                        char c = sb[i];
                        if (i == toReverse.Length - 1)
                        {
                            if (c == '1')
                            {
                                resultSb.Append('0');
                            }
                        }
                        resultSb.Append(c);

                    }

                    if (numberTypeChecker.HasNegativeSign)
                    {
                        return ToMinimumDigits.MakeBinaryOrNull(BigNumberCalculator.GetTwosComplementOrNull(resultSb.ToString()));
                    }
                    else
                    {
                        return ToMinimumDigits.MakeBinaryOrNull(resultSb.ToString());
                    }

                }
                else if (numberTypeChecker.NumberType == ENumberType.None)
                {
                    return null;
                }
                return null;
            }

            private static readonly Dictionary<string, char> binaryToHexCharacter = new Dictionary<string, char> {
                {"0000", '0'},
                {"0001", '1'},
                {"0010", '2'},
                {"0011", '3'},
                {"0100", '4'},
                {"0101", '5'},
                {"0110", '6'},
                {"0111", '7'},
                {"1000", '8'},
                {"1001", '9'},
                {"1010", 'a'},
                {"1011", 'b'},
                {"1100", 'c'},
                {"1101", 'd'},
                {"1110", 'e'},
                {"1111", 'f'}
            };


            public static string ToHexOrNull(string num)
            {
                NumberTypeChecker numberTypeChecker = new NumberTypeChecker(num);
                if (numberTypeChecker.NumberType == ENumberType.Binary)
                {
                    string numberPart = numberTypeChecker.NumberPart;

                    int blocksCount;
                    if (numberPart.Length % 4 != 0)
                    {
                        blocksCount = numberPart.Length / 4 + 1;
                    }
                    else
                    {
                        blocksCount = numberPart.Length / 4;
                    }
                    int surplusCount = blocksCount * 4 - numberPart.Length;

                    StringBuilder fullBinary = new StringBuilder();

                    for (int i = 0; i < surplusCount; i++)
                    {
                        fullBinary.Append(numberPart[0].ToString());
                    }

                    for (int i = 0; i < numberPart.Length; i++)
                    {
                        fullBinary.Append(numberPart[i].ToString());
                    }

                    StringBuilder result = new StringBuilder("0x");

                    string fb = fullBinary.ToString();
                    for (int i = 0; i < blocksCount; i++)
                    {
                        string key = fb.Substring(i * 4, 4);
                        result.Append(Char.ToUpper(binaryToHexCharacter[key]).ToString());
                    }

                    return result.ToString();

                }
                else if (numberTypeChecker.NumberType == ENumberType.Hex)
                {
                    return num;
                }
                else if (numberTypeChecker.NumberType == ENumberType.Decimal)
                {
                    string binary = BigNumberCalculator.ToBinaryOrNull(num);
                    return BigNumberCalculator.ToHexOrNull(binary);
                }
                else if (numberTypeChecker.NumberType == ENumberType.None)
                {
                    return null;
                }
                return null;
            }

            public static string ToDecimalOrNull(string num)
            {
                NumberTypeChecker numberTypeChecker = new NumberTypeChecker(num);
                if (numberTypeChecker.NumberType == ENumberType.Binary)
                {
                    string numberPart = numberTypeChecker.NumberPart;
                    StringAdder sa;


                    StringBuilder resultSb;
                    if (numberPart[0] == '0')
                    {
                        resultSb = new StringBuilder();
                    }
                    else
                    {
                        resultSb = new StringBuilder("-");
                        string positiveNum = BigNumberCalculator.GetTwosComplementOrNull(num);
                        NumberTypeChecker positiveNumberTypeChecker = new NumberTypeChecker(positiveNum);
                        numberPart = positiveNumberTypeChecker.NumberPart;
                    }

                    string result = "0";
                    int pos = 0;
                    string toAdded = "1";

                    for (int i = numberPart.Length - 1; i >= 0; i--)
                    {
                        char c = numberPart[i];

                        if (pos == 0)
                        {
                            if (c == '1')
                            {
                                sa = new StringAdder(result, "1", 10);
                                result = sa.Result;
                            }

                        }
                        else
                        {
                            StringMultiplication sm = new StringMultiplication(toAdded, "2");
                            toAdded = sm.Result;
                            if (c == '1')
                            {
                                sa = new StringAdder(result, toAdded, 10);
                                result = sa.Result;
                            }
                        }
                        pos++;
                    }

                    return resultSb.Append(result).ToString();

                }
                else if (numberTypeChecker.NumberType == ENumberType.Hex)
                {
                    string binary = BigNumberCalculator.ToBinaryOrNull(num);
                    return BigNumberCalculator.ToDecimalOrNull(binary);
                }
                else if (numberTypeChecker.NumberType == ENumberType.Decimal)
                {
                    return num;
                }
                else if (numberTypeChecker.NumberType == ENumberType.None)
                {
                    return null;
                }
                return null;
            }

            private string MakeFullBitBinaryOrNull(string num)
            {
                StringBuilder fullBinary = new StringBuilder();
                int surplusCount = this.mBitCount - (num.Length);

                if (surplusCount > 0)
                {
                    for (int i = 0; i < surplusCount; i++)
                    {
                        fullBinary.Append(num[0].ToString());
                    }
                    fullBinary.Append(num);
                    return fullBinary.ToString();
                }
                else if (surplusCount == 0)
                {
                    return num;
                }
                else
                {
                    return null;
                }

            }

            public string AddOrNull(string num1, string num2, out bool bOverflow)
            {
                string binaryNum1 = BigNumberCalculator.ToBinaryOrNull(num1).Substring(2);
                string binaryNum2 = BigNumberCalculator.ToBinaryOrNull(num2).Substring(2);

                binaryNum1 = this.MakeFullBitBinaryOrNull(binaryNum1);
                binaryNum2 = this.MakeFullBitBinaryOrNull(binaryNum2);

                if (binaryNum1 == null || binaryNum2 == null)
                {
                    bOverflow = false;
                    return null;
                }

                StringBuilder sb = new StringBuilder("0b");
                StringAdder sa = new StringAdder(binaryNum1, binaryNum2, 2);
                string addedResult = sa.NotTrimedResult;

                for (int i = 0; i < this.mBitCount; i++)
                {
                    int idx = i + addedResult.Length - this.mBitCount;
                    if (idx < 0)
                    {
                        continue;
                    }
                    sb.Append(addedResult[idx]);
                }

                string binary = sb.ToString();

                if (BigNumberCalculator.ToDecimalOrNull(binary) == "0")
                {
                    bOverflow = false;
                }
                else if ((binaryNum1[0] == binaryNum2[0]) && (binaryNum1[0] != binary[2]))
                {
                    bOverflow = true;
                }
                else
                {
                    bOverflow = false;

                }


                if (this.Mode == EMode.Binary)
                {
                    return binary;
                }
                else if (this.Mode == EMode.Decimal)
                {
                    return BigNumberCalculator.ToDecimalOrNull(binary);
                }

                return null;




            }

            public string SubtractOrNull(string num1, string num2, out bool bOverflow)
            {
                string binary1 = BigNumberCalculator.ToBinaryOrNull(num1);
                string binary2 = BigNumberCalculator.ToBinaryOrNull(num2);

                string binaryNum1 = this.MakeFullBitBinaryOrNull(binary1.Substring(2));
                string binaryNum2 = this.MakeFullBitBinaryOrNull(binary2.Substring(2));

                StringBuilder sb = new StringBuilder("0b");
                sb.Append(binaryNum2);

                string twoComOfBinary2 = BigNumberCalculator.GetTwosComplementOrNull(sb.ToString());

                return this.AddOrNull(binary1, twoComOfBinary2, out bOverflow);
            }
        }
    }
}
