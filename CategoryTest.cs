using FluentAssertions;
using LeagueStore.Domain.Entities;
using System;
using Xunit;
using LeagueStore.Domain.ValueObjects;

namespace LeagueStore.Domain.Tests
{
    public class CategoryTest
    {
        [Fact]
        public void CreateCategory_WithValideParameters_ResultValidState()
        {
            Action action = () => new Category("Defesa");
            action.Should().NotThrow<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateCategory_WithBlankParameters_ResultInvalidState()
        {
            Action action = () => new Category("    ");
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateCategory_WithTooLongParameters_ResultInvalidState()
        {
            Action action = () => new Category("alsdkaoskdpaskdpajskdjasodjasldkjalskdjaskjdlaskjdlaksjdlkasjdlkasj");
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateCategory_WithSpecialParameters_ResultInvalidState()
        {
            Action action = () => new Category ("@sd");
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
    }
}

