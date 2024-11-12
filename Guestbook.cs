using System.Text.Json;

namespace reviews
{
    public class Guestbook
    {
        private string filename = "reviews.json";
        private List<Review> reviews = new List<Review>();

        // constructor
        public Guestbook() {
            if (File.Exists(filename) == true) {
                string jsonString = File.ReadAllText(filename);
                reviews = JsonSerializer.Deserialize<List<Review>>(jsonString)!;
            }
        }

        // lägg till recension
        public Review addReview(string message, string name) {
            Review obj = new Review();
            obj.Message = message;
            obj.Name = name;
            reviews.Add(obj);
            marshal();
            return obj;
        }

        // ta bort recension
        public int deleteReview(int index) {
            reviews.RemoveAt(index);
            marshal();
            return index;
        }

        // hämta alla recensioner
        public List<Review> getReviews() {
            return reviews;
        }

        private void marshal()
        {
            var jsonString = JsonSerializer.Serialize(reviews);
            File.WriteAllText(filename, jsonString);
        }
    }
}