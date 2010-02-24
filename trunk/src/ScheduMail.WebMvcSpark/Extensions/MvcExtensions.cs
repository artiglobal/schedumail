using System.Web.Mvc;

namespace ScheduMail.WebMvcSpark.Extensions
{
    /// <summary>
    /// General Extensions helpers
    /// </summary>
    public static class MyExtensions
    {
        /// <summary>
        /// Copies the state of to model.
        /// </summary>
        /// <param name="ruleException">The rule exception.</param>
        /// <param name="modelState">State of the model.</param>
        /// <param name="prefix">The prefix.</param>
        public static void CopyToModelState(this RuleException ruleException, ModelStateDictionary modelState, string prefix)
        {
            foreach (string key in ruleException.Errors)
            {
                foreach (string value in ruleException.Errors.GetValues(key))
                {
                    if (string.IsNullOrEmpty(prefix))
                    {
                        modelState.AddModelError(key, value);
                    }
                    else
                    {
                        modelState.AddModelError(prefix + "." + key, value);
                    }
                }
            }
        }

        /// <summary>
        /// Copies the state of to model.
        /// </summary>
        /// <param name="ruleException">The rule exception.</param>
        /// <param name="modelState">State of the model.</param>
        public static void CopyToModelState(this RuleException ruleException, ModelStateDictionary modelState)
        {
            foreach (string key in ruleException.Errors)
            {
                foreach (string value in ruleException.Errors.GetValues(key))
                {
                    modelState.AddModelError(key, value);
                }
            }
        }
    }
}
