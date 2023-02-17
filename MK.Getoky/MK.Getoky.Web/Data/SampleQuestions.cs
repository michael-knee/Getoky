using System;
using MK.Getoky.Web.Models;

namespace MK.Getoky.Web.Data
{
	public class SampleQuestions
	{
        public static readonly List<Question> Questions = new List<Question>()
        {
            new Question("Where is your next holiday destination?"),
            new Question("How would you survive a crocodile attack?"),
            new Question("Would you rather go kite surfing in Hawaii or read a book next to a fire?"),
            new Question("What's your least favourite food?"),
            new Question("Do you scrunch or fold?"),
            new Question("If silence speaks volumes, how much does a mime weigh?"),
            new Question("If you could name a restaurant/bar/etc, what would you call it?"),
            new Question("What fictional character would you choose to be?"),
            new Question("If your pet could talk, what would its catchphrase be?"),
            new Question("What’s a pet peeve that you would make illegal if you could?"),
            new Question("If you could change the ending of any famous movie, which movie would it be? What would your new ending be?"),
            new Question("If you could only wear one color for the rest of your life, what would it be and why?"),
        };
	}
}

