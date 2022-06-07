using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace HW10.Services.Calculator
{
    public class CalculatorVisitor :ExpressionVisitor
    {
        protected override Expression VisitBinary(BinaryExpression node)
        {
            var leftNodeTask = Task.Run(()=>(double)((ConstantExpression)Visit(node.Left)).Value);
            var rightNodeTask = Task.Run(()=>(double)((ConstantExpression)Visit(node.Right)).Value);
            Thread.Sleep(1000);
            Task.WhenAll(leftNodeTask, rightNodeTask);
            var leftNode = leftNodeTask.Result;
            var rightNode = rightNodeTask.Result;

            return node.NodeType switch
            {
                ExpressionType.Add => Expression.Constant(leftNode + rightNode, typeof(double)),
                ExpressionType.Subtract => Expression.Constant(leftNode - rightNode, typeof(double)),
                ExpressionType.Multiply => Expression.Constant(leftNode * rightNode, typeof(double)),
                ExpressionType.Divide => Expression.Constant(leftNode / rightNode, typeof(double))
            };
        }

        protected override Expression VisitConstant(ConstantExpression node) => node;
    }
}