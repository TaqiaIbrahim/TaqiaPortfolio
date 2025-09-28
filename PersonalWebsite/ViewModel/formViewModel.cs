using TaqiaPortFolio.Models;

namespace TaqiaPortFolio.ViewModel
{
    public class formViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<Training> Training { get; set; }
        public IEnumerable<AboutMe> aboutMe {  get; set; }
        public IEnumerable<Education>  educations{ get; set; }
        public IEnumerable<Expericence> experiences { get; set; }
        
        public IEnumerable<Gallery> Galleries { get; set; }
        public IEnumerable<Service> services { get; set; }
        public IEnumerable<Skills> skills { get; set; }
        
        public IEnumerable<ClientOpinion> clientOpinion { get; set;}

        

    }
}
