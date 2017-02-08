using System.Linq.Expressions;
using System.Reflection;

namespace Core.Extensions
{
	public static class ExpressionExtensions
	{
		public static MemberInfo GetMemberInfo(this Expression expression)
    {
      var lambdaExpression = (LambdaExpression) expression;
      return (!(lambdaExpression.Body is UnaryExpression) ? (MemberExpression) lambdaExpression.Body : (MemberExpression) ((UnaryExpression) lambdaExpression.Body).Operand).Member;
    }
		//public static string GetBindingPath(this Expression expression)
  //  {
  //    var lambdaExpression = (LambdaExpression) expression;
		//	var bodyExpression = lambdaExpression.Body;

  //    var mi = (!(lambdaExpression.Body is UnaryExpression) ? (MemberExpression) lambdaExpression.Body : (MemberExpression) ((UnaryExpression) lambdaExpression.Body).Operand).Member;
   
  //  }
	}
}
