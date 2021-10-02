using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    public class Scanner
    {
        private string _regexp = "";
        private int _index = 0;
        private int _state = 0;
        public Scanner(string regexp)
        {
            _regexp = regexp + (char)TokenType.EOF;
            _index = 0;
            _state = 0;
        }
        public Token GetToken()
        {
            Token result = new Token() { Value = ((char)0).ToString() };
            bool tokenFound = false;
            string cadena = null;
            while (!tokenFound)
            {
                char peek = _regexp[_index];
                switch (_state)
                {
                    case 0:
                        
                        while (char.IsWhiteSpace(peek))
                        {
                            _index++;
                            peek = _regexp[_index];
                            
                        }
                        switch (peek)
                        {
                           
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:                      
                            case (char)TokenType.Plus:
                            case (char)TokenType.Multiply:
                            case (char)TokenType.EOF:
                            case (char)TokenType.Minus:
                            case (char)TokenType.Divide:
                                tokenFound = true;
                                result.Tag = (TokenType)peek;
                                break;
                            default:
                                if (char.IsDigit(peek))
                                {
                                    cadena = cadena + peek;
                                    _state = 2;


                                }
                                else
                                {
                                    throw new Exception("Lex Error");
                                }
                                break;
                        }
                        break;
                    case 1:
                        switch (peek)
                        {
                            case (char)TokenType.LParen:
                            case (char)TokenType.RParen:
                            case (char)TokenType.Plus:
                            case (char)TokenType.Multiply:
                            case (char)TokenType.Minus:
                            case (char)TokenType.Divide:
                            case '\\':
                            case ' ':
                                tokenFound = true;
                                result.Tag = TokenType.Symbol;
                                result.Value = peek.ToString();
                                break;
                            case 'E':
                                tokenFound = true;
                                result.Tag = TokenType.Null;
                                break;
                            case '0':
                                tokenFound = true;
                                result.Tag = TokenType.Empty;
                                break;
                            default:
                                throw new Exception("Lex Error");
                        }
                        break;
                    case 2:

                        if (char.IsDigit(peek))
                        {
                            cadena = cadena + peek;
                            //Console.WriteLine(cadena);
                            _state = 2;

                        }
                        else
                        {

                       
                            tokenFound = true;
                            result.Tag = TokenType.Number;
                            result.Value = cadena;
                            _state = 0;
                            _index--;
                        }
                        break;
                    default:
                        break;
                }
                _index++;
            }//while token found
            _state = 0;
            return result;
        }//get token
    }
}
