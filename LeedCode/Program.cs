using System;


using System.Text;
using System.Threading.Tasks;

//using MailKit.Net.Smtp;
//using MimeKit;
using System;
using System.Net.Mail;
using System.Net;

namespace LeedCode
{
	class Program
	{
		public static  void Main(string[] args)
		{
			string result = "";
			SendGmail();


			Parallel.Invoke(() =>
			{
				System.Threading.Thread.Sleep(5000);

			});


		  var testClass = new LeetCode3LongestSubstring();
			string testString = "abba";

			//var result = testClass.LengthOfLongestSubstring(testString);

			string testString2 = "abcabcde";
			var result2= testClass.LengthOfLongestSubstring(testString2);

			string testString3 = "ababc";
			var result3 = testClass.LengthOfLongestSubstring(testString3);
			Console.WriteLine(result);
			Console.WriteLine(result2);
			Console.WriteLine(result3);
			Console.ReadLine();
		}


		/// <summary>
		/// 使用 阿里云邮件服务获取qq邮件服务
		/// </summary>
		/// <param name="address"></param>
		/// <param name="title"></param>
		/// <param name="content"></param>
		/// <returns></returns>
		//public static bool send()
		//{
		//	var message = new MimeMessage();
		//	message.From.Add(new MailboxAddress("发件人备注", "发信账户"));
		//	message.To.Add(new MailboxAddress("收件人备注", "bmxzcl@163.com"));
		//	message.Subject = string.Format("邮件标题 ", "test");  //邮件标题     

		//	message.Body = new TextPart("plain")
		//	{
		//		Text = string.Format("{0}内容：{1} ", "test", "test")//邮件内容。
		//	};
		//	using (var client = new ImapClient())
		//	{
		//		// For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
		//		//client.EnableSsl = true;
		//		//不和请求一块发送。
		//		//client.UseDefaultCredentials = false;
		//		client.ServerCertificateValidationCallback = (s, c, h, e) => true;
		//		client.Connect("smtp.163.com", 465, true);// 取决与你发信账户的类型 一般的qq邮箱（需要开启授权码，以及smtp服务，密码也就是授权码了）使用 ："smtp.qq.com" 126邮箱类似等，类似
		//		client.											   // Note: only needed if the SMTP server requires authentication
		//		client.Authenticate("bmxzcl@163.com", "Linda900312");
		//		try
		//		{
		//			client.Send(message);//发送邮件
		//			client.Disconnect(true);
		//			return true;
		//		}
		//		catch (Exception ex)
		//		{
		//			return false;
		//			throw ex;
		//		}

		//	}

		//}

		public static void SendQQ()
		{
				//实例化一个发送邮件类。
				MailMessage mailMessage = new MailMessage();
				//发件人邮箱地址，方法重载不同，可以根据需求自行选择。
				mailMessage.From = new MailAddress("529549623@qq.com");
				//收件人邮箱地址。
				mailMessage.To.Add(new MailAddress("529549623@qq.com"));
				//邮件标题。
				mailMessage.Subject = "发送邮件测试";
				//邮件内容。
				mailMessage.Body = "这是我给你发送的第一份邮件哦！";

			try
			{
				//实例化一个SmtpClient类。
				SmtpClient client = new SmtpClient();
				//在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
				client.Host = "smtp.qq.com";
				//使用安全加密连接。
				client.EnableSsl = true;
				//不和请求一块发送。
				client.UseDefaultCredentials = false;
				//验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
				client.Credentials = new NetworkCredential("529549623@qq.com", "@1234Linda");
				client.Port = 587;
				//发送
				client.Send(mailMessage);
			}catch(Exception e)
			{
				throw e;
			}
				
			
		}

		public static void SendGmail()
		{
			var smtpClient = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new NetworkCredential("baomengxin@gmail.com", "Linda@12345"),
				EnableSsl = true,
				DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
			};

			smtpClient.Send("bmxzcl@163.com", "bmxzcl@163.com", "subject", "body");
		}



		//public static  bool SendMail( string errorMsg)
		//{
		//	//声明一个Mail对象
		//	System.Net.Mail.MailMessage mymail = new MailMessage();
		//	//发件人地址
		//	//如是自己，在此输入自己的邮箱
		//	mymail.From = new MailAddress("bmxzcl@163.com", "Linda", Encoding.UTF8);
		//	//收件人地址
		//	//mymail.To.Add(new MailAddress("primary@amazon.fr"));
		//	mymail.To.Add(new MailAddress("bmxzcl@163.com"));
		//	//邮件主题
		//	mymail.Subject = "Demande pour information pour la commande 402-6732028-8692368 ";
		//	//邮件标题编码
		//	mymail.SubjectEncoding = Encoding.ASCII;
		//	//发送邮件的内容
		//	mymail.Body = "Bonjour, j'ai renvoyé cette commande 402-6732028-8692368 pendant deux mois, mais je n'ai toujours pas reçu le remboursement. Pouvez-vous voir ce qui s'est passé?";
		//	//邮件内容编码
		//	mymail.BodyEncoding = Encoding.ASCII;


		//	////抄送到其他邮箱
		//	//foreach (var str in sender.Cc)
		//	//{
		//	//	mymail.CC.Add(new MailAddress(str));
		//	//}

		//	////是否是HTML邮件
		//	//mymail.IsBodyHtml = sender.IsBodyHtml;
		//	////邮件优先级
		//	//mymail.Priority = sender.MailPriority;
		//	//创建一个邮件服务器类
		//	SmtpClient myclient = new SmtpClient();

		//	myclient.DeliveryMethod = SmtpDeliveryMethod.Network;
		//	myclient.UseDefaultCredentials = false;
		//	myclient.EnableSsl = true;
		//	//myclient.Host = "smtp.gmail.com";
		//	//myclient.Port = 587;
		//	//myclient.Credentials = new NetworkCredential("baomengxin@gmail.com", "Linda@12345");


		//	myclient.Host = "smtp.163.com";

		//	myclient.Port = 465;

		//	myclient.EnableSsl = true;

		//	myclient.UseDefaultCredentials = true;
		//	myclient.Credentials = new NetworkCredential("bmxzcl@163.com", "Linda900312");
		//	//验证登录
		//	//myclient.Credentials = new NetworkCredential("baomengxin@gmail.com", "");//"@"输入有效的邮件名, "*"输入有效的密码
		//	try
		//	{
		//		myclient.Send(mymail);
		//		errorMsg = "";
		//		return true;
		//	}
		//	catch (Exception ex)
		//	{
		//		errorMsg = ex.Message;
		//		return false;
		//	}

		//	//iqqtmmikgwydhhci
		//}
	}
}
