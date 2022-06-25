using System;
using System.Collections.Generic;
using System.Text;

namespace CVFilter.Domain.Core.SqlQueries
{
    public class Queries
    {
        public static string CreateApplicationCommandQuery =
            @"INSERT INTO Applicants ([Name],Matches,Path,PhoneNumber,Email,TotalExperience,IsActive,IsDeleted,CreatedDate,UpdatedDate)
 VALUES (@Name,@Matches,@Path,@PhoneNumber,@Email,@TotalExperience,@IsActive,@IsDeleted,@CreatedDate,@UpdatedDate) 
SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public static string CreateApplicantEducationRelationQuery =
            @"INSERT INTO ApplicantEducationRelations (ApplicantId,SchoolName)
VALUES (@ApplicantId,@SchoolName)
 SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public static string CreateApplicantLanguageRelationQuery = @"INSERT INTO ApplicantLanguageRelations (ApplicantId,Language)
 VALUES (@ApplicantId,@Langugage) SELECT CAST(SCOPE_IDENTITY() AS INT)";
        public static string DeleteApplicantQuery = "DELETE FROM Applicants WHERE ID = @Id";
        public static string DeleteApplicantEducationRelationQuery = "DELETE FROM ApplicantEducationRelations WHERE ID = @Id";
        public static string DeleteApplicantLanguageRelationQuery = "DELETE FROM ApplicantEducationRelations WHERE ID = @Id";
        public static string UpdateApplicantQuery = @"UPDATE Applicants SET [Name] = @Name, Matches = @Matches, Path = @Path, Email = @Email, PhoneNumber = @PhoneNumber,TotalExperience=@TotalExperience, IsActive = @IsActive, IsDeleted = @IsDeleted, UpdatedDate = @UpdatedDate WHERE Id = @Id";
        public static string CreateLogQuery = @"INSERT INTO Logs (ErrorMessage,IsActive,IsDeleted,CreatedDate,UpdatedDate)
 VALUES (@ErrorMessage,@IsActive,@IsDeleted,@CreatedDate,@UpdatedDate) SELECT CAST(SCOPE_IDENTITY() AS INT)";
    }
}
