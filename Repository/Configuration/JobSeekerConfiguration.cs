using System;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class JobSeekerConfiguration : IEntityTypeConfiguration<JobSeeker>
    {
        public void Configure(EntityTypeBuilder<JobSeeker> builder)
        {
            builder.HasData(

                new Country
                {
                   Id = 1,
                   Name = "Australia"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Azerbaijan"
                 },
                  new Country
                  {
                      Id = 3,
                      Name = "Bangladesh"
                  }, new Country
                  {
                      Id = 4,
                      Name = "Bahrain"
                  },
                   new Country
                   {
                       Id = 5,
                       Name = "China"
                   },
                    new Country
                    {
                        Id = 6,
                        Name = "Germany"
                    },
                    new Country
                    {
                        Id = 7,
                        Name = "India"
                    },
                     new Country
                     {
                         Id = 8,
                         Name = "United States of America"
                     },
                      new Country
                      {
                          Id = 9,
                          Name = "United Arab Emirates"
                      }
                );
        }
    }
}

