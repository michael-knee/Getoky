using System;
namespace MK.Getoky.Web.Models
{
	public class PersonQuestionAllocation
	{
		public Person Person { get; set; }
		public Question Question { get; set; }

		public PersonQuestionAllocation(Person person, Question question)
		{
			Person = person;
			Question = question;
		}
	}
}

