using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace EasyAbp.EasyComment.CommentUsers
{
    public class CommentUser : AggregateRoot<Guid>, IUser, IUpdateUserData
    {
        public Guid? TenantId { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public bool EmailConfirmed { get; protected set; }
        public string PhoneNumber { get; protected set; }
        public bool PhoneNumberConfirmed { get; protected set; }
        public string Avatar { get; protected set; }

        protected CommentUser()
        {
        }

        public CommentUser(IUserData user) : base(user.Id)
        {
            TenantId = user.TenantId;
            UpdateInternal(user);
        }

        public virtual bool Update(IUserData user)
        {
            if (Id != user.Id)
            {
                throw new ArgumentException($"Given User's Id '{user.Id}' does not match to this User's Id '{Id}'");
            }

            if (TenantId != user.TenantId)
            {
                throw new ArgumentException($"Given User's TenantId '{user.TenantId}' does not match to this User's TenantId '{TenantId}'");
            }

            if (Equals(user))
            {
                return false;
            }

            UpdateInternal(user);
            return true;
        }

        protected virtual bool Equals(IUserData user)
        {
            return Id == user.Id &&
                   TenantId == user.TenantId &&
                   UserName == user.UserName &&
                   Name == user.Name &&
                   Surname == user.Surname &&
                   Email == user.Email &&
                   EmailConfirmed == user.EmailConfirmed &&
                   PhoneNumber == user.PhoneNumber &&
                   PhoneNumberConfirmed == user.PhoneNumberConfirmed;
        }

        protected virtual void UpdateInternal(IUserData user)
        {
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            EmailConfirmed = user.EmailConfirmed;
            PhoneNumber = user.PhoneNumber;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            UserName = user.UserName;
        }

        public virtual CommentUser SetAvatar([NotNull] string avatar)
        {
            Avatar = Check.NotNullOrWhiteSpace(avatar, nameof(avatar));
            return this;
        }
    }
}