using SearchWebApp.Utils;
using System;

namespace SearchWebApp.Models
{
    public class AnswerModel
    {
        public Item[] items { get; set; }
        public bool has_more { get; set; }
        public int quota_max { get; set; }
        public int quota_remaining { get; set; }
    }

    public class Item
    {
        public string[] tags { get; set; }
        public Owner owner { get; set; }
        public bool is_answered { get; set; }
        public int view_count { get; set; }
        public int accepted_answer_id { get; set; }
        public int answer_count { get; set; }
        public int score { get; set; }
        public int last_activity_date { get; set; }
        public int creation_date { get; set; }
        public int question_id { get; set; }
        public string content_license { get; set; }
        public string link { get; set; }
        public string title { get; set; }

        public DateTime DateCreate()
        {
            return TimeUtils.ConvertToDateTime(creation_date);
        }
        public DateTime LastActivityDate()
        {
            return TimeUtils.ConvertToDateTime(last_activity_date);
        }
    }

    public class Owner
    {
        public int account_id { get; set; }
        public int reputation { get; set; }
        public int user_id { get; set; }
        public string user_type { get; set; }
        public int accept_rate { get; set; }
        public string profile_image { get; set; }
        public string display_name { get; set; }
        public string link { get; set; }
    }
}