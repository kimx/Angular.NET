﻿using System.Web;
using System.Web.Mvc;

namespace AxSoft.Angular.Net
{
	/// <summary>
	/// Represents an AngularJS repeat context.
	/// </summary>
	/// <typeparam name="TModel">The type of the model.</typeparam>
	public class NgRepeatContext<TModel> : AngularBindingSubcontext<TModel>
	{
		private const string DirectiveName = "ng-repeat";

		internal NgRepeatContext(HtmlHelper<TModel> helper, string subexpression, string prefix)
			: base(helper, subexpression, prefix)
		{
		}

		/// <summary>
		/// Gets the name of the context item.
		/// </summary>
		public override string Item
		{
			get { return "$item"; }
		}

		/// <summary>
		/// Renders the ng-repeat directive.
		/// </summary>
		public override IHtmlString RenderDirective()
		{
			return RenderDirective(null);
		}

		/// <summary>
		/// Renders the ng-repeat directive
		/// </summary>
		/// <param name="filter">An optional filter to add to the binding.</param>
		public IHtmlString RenderDirective(string filter)
		{
			if (!string.IsNullOrWhiteSpace(filter))
			{
				filter += " | " + filter;
			}
			string prefix = Prefix != null ? Prefix + AngularConfiguration.PropertyDelimiter : null;
			return CreateHtmlAttribute(DirectiveName, string.Format("{0} in {1}{2}{3}", Item, prefix, Subexpression, filter));
		}
	}
}