using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.EntityLayer.Concrete
{
	[Table("ArticleTags")]
	public class ArticleTag
	{
        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("TagId")]
        public int TagId { get; set; }
    }
}
