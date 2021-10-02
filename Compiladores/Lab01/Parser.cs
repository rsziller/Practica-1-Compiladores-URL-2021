using System;
using System.Collections.Generic;
using System.Text;

namespace Lab01
{
    class Parser
    {
        Scanner _scanner;
        Token _token;
        private void M()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                    Match(TokenType.LParen);
                    E();
                    Match(TokenType.RParen);
                    break;
                case TokenType.Number:
                    Match(TokenType.Number);
                    break;
                default:
                    //throw new Exception("Error de sintaxis");
                    break;
            }
        }
        private void F()
        {
            switch (_token.Tag)
            {

                case TokenType.Minus:
                    Match(TokenType.Minus);
                    M();
                    break;
                case TokenType.LParen:
                case TokenType.Number:
                    M();
                    break;
                default:
                    throw new Exception("Error de sintaxis");
                    //break;
            }
        }

        /*private void TP()
         {
             switch (_token.Tag)
             {

                 case TokenType.Multiply:
                    Match(TokenType.Multiply);
                    Match(TokenType.Multiply);
                    F();
                     TP();
                     break;
                 case TokenType.Divide:
                     Match(TokenType.Divide);
                     F();
                     TP();
                     break;
                 case TokenType.RParen:
                     Match(TokenType.RParen);
                     M();
                     break;
                 default:
                     break;
             }
         }*/

        private void TP()
        {
            switch (_token.Tag)
            {

                case TokenType.Multiply:
                case TokenType.Divide:
                    Match(_token.Tag);
                    F();
                    TP();
                    break;
                default:
                    break;
            }
        }



        private void T()
        {
            switch (_token.Tag)
            {

                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Number:
                    F();
                    TP();
                    break;
                default:
                    throw new Exception("Error de sintaxis");
                    //break;
            }
        }


        /*private void EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Plus:
                    Match(TokenType.Plus);
                    T();
                    EP();
                    break;
                case TokenType.Minus:
                    Match(TokenType.Minus);
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }*/


        private void EP()
        {
            switch (_token.Tag)
            {
                case TokenType.Plus:
                case TokenType.Minus:
                    Match(_token.Tag);
                    T();
                    EP();
                    break;
                default:
                    break;
            }
        }



        private void E()
        {
            switch (_token.Tag)
            {

                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Number:
                    T();
                    EP();
                    break;
                default:
                    //break;
                    throw new Exception("Error de sintaxis");
            }
        }

        private void Match(TokenType tag)
        {
            if (_token.Tag == tag)
            {
                _token = _scanner.GetToken();

            }
            else
            {
                throw new Exception("Error de sintaxis");
            }
        }
        public void Parse (string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            switch (_token.Tag)
            {

                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Number:
                    E();
                    break;
                default:
                    break;
            }

            Match(TokenType.EOF);
        }
    }
}
