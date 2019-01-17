using System.ComponentModel.DataAnnotations;
using Tot.Api.Helpers;

namespace Tot.Api.Models
{
    public class CreateFeedbackRequest
    {
        public CreateFeedbackRequest(string description, int groupId)
        {
            Description = description;
            GroupId = groupId;
        }

        [Required(ErrorMessage = "Campo Descrição é obrigatório.")]
        [LengthValidation(3, 280, "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Campo Grupo é obrigatório.")]
        public int GroupId { get; set; }
    }
}