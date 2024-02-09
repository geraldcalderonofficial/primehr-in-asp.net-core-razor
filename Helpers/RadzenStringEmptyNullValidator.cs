using Microsoft.AspNetCore.Components;
using Radzen;

namespace HRMSv4.Client.Helpers
{
    public class RadzenStringEmptyNullValidator : Radzen.Blazor.ValidatorBase
    {
        [Parameter]
        public override string Text { get; set; } = "Field required";

        protected override bool Validate(IRadzenFormComponent component)
        {
            var data = component.GetValue();
            Text = component.Name + " is required";
            var validatedString = data != null ? GetValidString(data.ToString()) : "";
            return validatedString != null && validatedString != "";
        }

        string GetValidString(string str)
        {
            string validString = "";
            if (str != null)
            {
                string[] newStr = str.Split(' ');
                List<string> validList = newStr.Where(c => c != "" && c != "\t" && c != "\n").ToList();
                foreach (string str1 in validList)
                {
                    if (validString != "")
                    {
                        validString += " " + str1;
                    }
                    else
                    {
                        validString = str1;
                    }
                }
            }

            return validString;
        }
    }
}
