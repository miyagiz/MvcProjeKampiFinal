using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concreate
{
    public class SkillCard
    {
        [Key]
        public int SkillCardID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string SchoolName { get; set; }

        [StringLength(30)]
        public string SkillName1 { get; set; }

        public int SkillPoint1 { get; set; }

        [StringLength(30)]
        public string SkillName2 { get; set; }

        public int SkillPoint2 { get; set; }

        [StringLength(30)]
        public string SkillName3 { get; set; }

        public int SkillPoint3 { get; set; }

        [StringLength(30)]
        public string SkillName4 { get; set; }

        public int SkillPoint4 { get; set; }

        [StringLength(30)]
        public string SkillName5 { get; set; }

        public int SkillPoint5 { get; set; }

        [StringLength(30)]
        public string SkillName6 { get; set; }

        public int SkillPoint6 { get; set; }

        [StringLength(30)]
        public string SkillName7 { get; set; }

        public int SkillPoint7 { get; set; }

        [StringLength(30)]
        public string SkillName8 { get; set; }

        public int SkillPoint8 { get; set; }

        [StringLength(30)]
        public string SkillName9 { get; set; }

        public int SkillPoint9 { get; set; }

        [StringLength(30)]
        public string SkillName10 { get; set; }

        public int SkillPoint10 { get; set; }

        [StringLength(200)]
        public string imageOfSkillCardHolder { get; set; }
    }
}
