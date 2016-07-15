using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZtherApiIntegration.Models.Faq;
using ZtherApiIntegration.API.Models;
using Microsoft.Rest;

namespace ZtherApiIntegration.API.Managers.Faq
{
    public class FaqManager
    {
        public static bool Create(FaqModel faqModel)
        {
            using (var client = new LandauPortalWebAPI())
            {
                var question = new Question();

                question.Brand = faqModel.Brand;
                question.FirstName = faqModel.FirstName;
                question.LastName = faqModel.LastName;
                question.Phone = faqModel.Phone;
                question.Email = faqModel.Email;
                question.Comments = faqModel.Comments;

                try
                {
                    client.Questions.CreateQuestions(question.Brand, question);
                    return true;
                }
                catch (Exception e)
                {
                    if (e is HttpOperationException)
                    {
                        var httpEx = (HttpOperationException)e;
                        return httpEx.Response.IsSuccessStatusCode;
                    }
                }

                return false;
            }
        }
    }
}