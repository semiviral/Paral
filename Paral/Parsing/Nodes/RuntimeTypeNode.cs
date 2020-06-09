#region

using Paral.Exceptions;
using Paral.Lexing;

#endregion

namespace Paral.Parsing.Nodes
{
    public class RuntimeTypeNode : BridgeNode
    {
        public RuntimeType Type { get; }

        public RuntimeTypeNode(RuntimeType type) => Type = type;

        protected override void AttemptInitializeChild(Token token)
        {
            switch (token.Type)
            {
                case TokenType.Identifier:
                    Child = new LabelNode(token.Value);
                    break;
                default:
                    ExceptionHelper.Error(token, ExceptionHelper.EXPECTED_IDENTIFIER);
                    break;
            }
        }
    }
}