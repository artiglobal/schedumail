using System;
using System.Collections.Specialized;
using System.Web.Mvc;

/// <summary>
/// Rule Exception wrapper class for Mvc framework.
/// </summary>
public class RuleException : Exception
{
    /// <summary>
    /// Gets or sets the errors.
    /// </summary>
    /// <value>The errors.</value>
    public NameValueCollection Errors { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="RuleException"/> class.
    /// </summary>
    /// <param name="key">The key value for exception type.</param>
    /// <param name="value">The value of excption.</param>
    public RuleException(string key, string value)
    {
        this.Errors = new NameValueCollection { { key, value } };
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RuleException"/> class.
    /// </summary>
    /// <param name="errors">The errors.</param>
    public RuleException(NameValueCollection errors)
    {
        this.Errors = errors;
    }

    /// <summary>
    /// Copies the state of to model.
    /// </summary>
    /// <param name="modelState">State of the model.</param>
    /// <param name="prefix">The prefix.</param>
    public void CopyToModelState(ModelStateDictionary modelState, string prefix)
    {
        foreach (string key in this.Errors)
        {
            foreach (string value in this.Errors.GetValues(key))
            {
                modelState.AddModelError(prefix + "." + key, value);
            }
        }
    }
}