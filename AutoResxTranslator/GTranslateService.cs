using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Google.Cloud.Translation.V2;

/* 
 * AutoResxTranslator
 * by Salar Khalilzadeh
 * 
 * https://autoresxtranslator.codeplex.com/
 * Mozilla Public License v2
 */
namespace AutoResxTranslator
{
	public class GTranslateService
	{
        private readonly TranslationClient Client = TranslationClient.Create();

		public async Task<string> TranslateAsync(
			string text,
			string sourceLng,
			string destLng
			)
		{
            var result = await Client.TranslateTextAsync(
                text, destLng, sourceLng);

            return result.TranslatedText;

		}

		public bool Translate(
			string text,
			string sourceLng,
			string destLng,
			out string result)
		{
			try
			{
                var res = Client.TranslateText(
                text, destLng, sourceLng);

                result = res.TranslatedText;

                return true;
				
			}
			catch (Exception ex)
			{
				result = ex.Message;
				return false;
			}
		}
		
		

	}

	
}
