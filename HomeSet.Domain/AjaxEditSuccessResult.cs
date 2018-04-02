using Microsoft.AspNetCore.Mvc;

namespace HomeSet.Domain
{
    public class AjaxEditSuccessResult : ContentResult
    {
        public const string SuccessValue = "ajax-edit-success";

        public AjaxEditSuccessResult()
        {
            Content = SuccessValue;
        }
    }
}
