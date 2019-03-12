using System;
using System.Linq;

namespace DotNetSurfer.Web.Helpers
{
    public static class EntityMapper
    {
        private static readonly short _level = 2;

        #region MapToDomain

        #region Nested
        public static Models.Topic MapToDomain(this DAL.Entities.Topic entityModel, short level = 1)
        {
            if (entityModel == null || level++ > _level)
            {
                return null;
            }

            return new Models.Topic
            {
                TopicId = entityModel.TopicId,
                Title = entityModel.Title,
                Description = entityModel.Description,
                Picture = entityModel.Picture,
                PictureMimeType = entityModel.PictureMimeType,
                PictureUrl = entityModel.PictureUrl,
                PostDate = entityModel.PostDate,
                ModifyDate = entityModel.ModifyDate,
                ShowFlag = entityModel.ShowFlag,
                UserId = entityModel.UserId,
                User = entityModel.User?.MapToDomain(level),
                Articles = entityModel.Articles?.Select(a => a.MapToDomain(level)).ToList()
            };
        }

        public static Models.Article MapToDomain(this DAL.Entities.Article entityModel, short level = 1)
        {
            if (entityModel == null || level++ > _level)
            {
                return null;
            }

            return new Models.Article
            {
                ArticleId = entityModel.ArticleId,
                Title = entityModel.Title,
                Content = entityModel.Content,
                Category = entityModel.Category,
                Picture = entityModel.Picture,
                PictureMimeType = entityModel.PictureMimeType,
                PictureUrl = entityModel.PictureUrl,
                PostDate = entityModel.PostDate,
                ModifyDate = entityModel.ModifyDate,
                ReadCount = entityModel.ReadCount,
                ShowFlag = entityModel.ShowFlag,
                TopicId = entityModel.TopicId,
                Topic = entityModel.Topic?.MapToDomain(level),
                UserId = entityModel.UserId,
                User = entityModel.User?.MapToDomain(level),
                Tags = entityModel.Tags?.Select(t => t.MapToDomain(level)).ToList()
            };
        }

        public static Models.Tag MapToDomain(this DAL.Entities.Tag entityModel, short level = 1)
        {
            if (entityModel == null || level++ > _level)
            {
                return null;
            }

            return new Models.Tag
            {
                TagId = entityModel.TagId,
                Content = entityModel.Content,
                ArticleId = entityModel.ArticleId,
                Article = entityModel.Article?.MapToDomain(level)
            };
        }

        public static Models.User MapToDomain(this DAL.Entities.User entityModel, short level = 1)
        {
            if (entityModel == null || level++ > _level)
            {
                return null;
            }

            return new Models.User
            {
                UserId = entityModel.UserId,
                Name = entityModel.Name,
                Password = entityModel.Password,
                Email = entityModel.Email,
                Title = entityModel.Title,
                Phone = entityModel.Phone,
                Address = entityModel.Address,
                Introduction = entityModel.Introduction,
                Birthdate = entityModel.Birthdate,
                Picture = entityModel.Picture,
                PictureMimeType = entityModel.PictureMimeType,
                PictureUrl = entityModel.PictureUrl,
                PermissionId = entityModel.PermissionId,
                Permission = entityModel.Permission?.MapToDomain(level),
                Topics = entityModel.Topics?.Select(t => t.MapToDomain(level)).ToList(),
                Articles = entityModel.Articles?.Select(a => a.MapToDomain(level)).ToList(),
                Announcements = entityModel.Announcements?.Select(anmt => anmt.MapToDomain(level)).ToList()
            };
        }

        public static Models.Permission MapToDomain(this DAL.Entities.Permission entityModel, short level = 1)
        {
            if (entityModel == null || level++ > _level)
            {
                return null;
            }

            return new Models.Permission
            {
                PermissionId = entityModel.PermissionId,
                PermissionType = (Models.PermissionType)Enum.Parse(typeof(Models.PermissionType), entityModel.PermissionType),
                Users = entityModel.Users.Select(u => u.MapToDomain(level)).ToList()
            };
        }

        public static Models.Announcement MapToDomain(this DAL.Entities.Announcement entityModel, short level = 1)
        {
            if (entityModel == null || level++ > _level)
            {
                return null;
            }

            return new Models.Announcement
            {
                AnnouncementId = entityModel.AnnouncementId,
                Content = entityModel.Content,
                PostDate = entityModel.PostDate,
                ModifyDate = entityModel.ModifyDate,
                ShowFlag = entityModel.ShowFlag,
                UserId = entityModel.UserId,
                User = entityModel.User?.MapToDomain(level),
                StatusId = entityModel.StatusId,
                Status = entityModel.Status?.MapToDomain()
            };
        }
        #endregion

        #region None Nested
        public static Models.Status MapToDomain(this DAL.Entities.Status entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Models.Status
            {
                StatusId = entity.StatusId,
                CurrentStatus = (Models.StatusType)Enum.Parse(typeof(Models.StatusType), entity.CurrentStatus)
            };
        }

        public static Models.Feature MapToDomain(this DAL.Entities.Feature entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Models.Feature
            {
                FeatureId = entity.FeatureId,
                Name = entity.Name,
                Description = entity.Description,
                Version = entity.Version,
                GithubUrl = entity.GithubUrl,
                DocumentUrl = entity.DocumentUrl,
                GuideUrl = entity.GuideUrl,
                FeatureType = (Models.FeatureType)Enum.Parse(typeof(Models.FeatureType), entity.FeatureType),
                ShowFlag = entity.ShowFlag
            };
        }
        #endregion

        #endregion

        #region MapToEntity

        #region Nested
        public static DAL.Entities.Topic MapToEntity(this Models.Topic domainModel, short level = 1)
        {
            if (domainModel == null || level++ > _level)
            {
                return null;
            }

            return new DAL.Entities.Topic
            {
                TopicId = domainModel.TopicId,
                Title = domainModel.Title,
                Description = domainModel.Description,
                Picture = domainModel.Picture,
                PictureMimeType = domainModel.PictureMimeType,
                PictureUrl = domainModel.PictureUrl,
                PostDate = domainModel.PostDate,
                ModifyDate = domainModel.ModifyDate,
                ShowFlag = domainModel.ShowFlag,
                UserId = domainModel.UserId,
                User = domainModel.User?.MapToEntity(level),
                Articles = domainModel.Articles?.Select(a => a.MapToEntity(level)).ToList()
            };
        }

        public static DAL.Entities.Article MapToEntity(this Models.Article domainModel, short level = 1)
        {
            if (domainModel == null || level++ > _level)
            {
                return null;
            }

            return new DAL.Entities.Article
            {
                ArticleId = domainModel.ArticleId,
                Title = domainModel.Title,
                Content = domainModel.Content,
                Category = domainModel.Category,
                Picture = domainModel.Picture,
                PictureMimeType = domainModel.PictureMimeType,
                PictureUrl = domainModel.PictureUrl,
                PostDate = domainModel.PostDate,
                ModifyDate = domainModel.ModifyDate,
                ReadCount = domainModel.ReadCount,
                ShowFlag = domainModel.ShowFlag,
                TopicId = domainModel.TopicId,
                Topic = domainModel.Topic?.MapToEntity(level),
                UserId = domainModel.UserId,
                User = domainModel.User?.MapToEntity(level),
                Tags = domainModel.Tags?.Select(t => t.MapToEntity(level)).ToList()
            };
        }

        public static DAL.Entities.Tag MapToEntity(this Models.Tag domainModel, short level = 1)
        {
            if (domainModel == null || level++ > _level)
            {
                return null;
            }

            return new DAL.Entities.Tag
            {
                TagId = domainModel.TagId,
                Content = domainModel.Content,
                ArticleId = domainModel.ArticleId,
                Article = domainModel.Article?.MapToEntity(level)
            };
        }

        public static DAL.Entities.User MapToEntity(this Models.User domainModel, short level = 1)
        {
            if (domainModel == null || level++ > _level)
            {
                return null;
            }

            return new DAL.Entities.User
            {
                UserId = domainModel.UserId,
                Name = domainModel.Name,
                Password = domainModel.Password,
                Email = domainModel.Email,
                Title = domainModel.Title,
                Phone = domainModel.Phone,
                Address = domainModel.Address,
                Introduction = domainModel.Introduction,
                Birthdate = domainModel.Birthdate,
                Picture = domainModel.Picture,
                PictureMimeType = domainModel.PictureMimeType,
                PictureUrl = domainModel.PictureUrl,
                PermissionId = domainModel.PermissionId,
                Permission = domainModel.Permission?.MapToEntity(level),
                Topics = domainModel.Topics?.Select(t => t.MapToEntity(level)).ToList(),
                Articles = domainModel.Articles?.Select(a => a.MapToEntity(level)).ToList(),
                Announcements = domainModel.Announcements?.Select(anmt => anmt.MapToEntity(level)).ToList()
            };
        }

        public static DAL.Entities.Permission MapToEntity(this Models.Permission domainModel, short level = 1)
        {
            if (domainModel == null || level++ > _level)
            {
                return null;
            }

            return new DAL.Entities.Permission
            {
                PermissionId = domainModel.PermissionId,
                PermissionType = domainModel.PermissionType.ToString(),
                Users = domainModel.Users?.Select(u => u.MapToEntity(level)).ToList()
            };
        }

        public static DAL.Entities.Announcement MapToEntity(this Models.Announcement domainModel, short level = 1)
        {
            if (domainModel == null || level++ > _level)
            {
                return null;
            }

            return new DAL.Entities.Announcement
            {
                AnnouncementId = domainModel.AnnouncementId,
                Content = domainModel.Content,
                PostDate = domainModel.PostDate,
                ModifyDate = domainModel.ModifyDate,
                ShowFlag = domainModel.ShowFlag,
                UserId = domainModel.UserId,
                User = domainModel.User?.MapToEntity(level),
                StatusId = domainModel.StatusId,
                Status = domainModel.Status?.MapToEntity()
            };
        }
        #endregion

        #region None Nested
        public static DAL.Entities.Status MapToEntity(this Models.Status domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            return new DAL.Entities.Status
            {
                StatusId = domainModel.StatusId,
                CurrentStatus = domainModel.CurrentStatus.ToString()
            };
        }
        #endregion

        #endregion
    }
}
