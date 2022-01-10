using FluentAssertions;
using LeagueStore.Domain.Entities;
using System;
using Xunit;
using LeagueStore.Domain.ValueObjects;

namespace LeagueStore.Domain.Tests
{
    public class ItemTest
    {
        [Fact]
        public void CreateItem_WithValideParameters_ResultValidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera você das amarras do destino", new Attack("2", "30"), new Defense("10", "1", "13"));
            action.Should().NotThrow<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithSpecialParameters_ResultInvalidState()
        {
            Action action = () => new Item("Ek@-de_Luden", "Um item poderoso que libera=você_das amarras do destino", new Attack("2", "30"), new Defense("10", "1", "13"));
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithEmptyParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera você das amarras do destino", new Attack("0", ""), new Defense("0", "0", "0"));
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithNullParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera você das amarras do destino", new Attack("0", null), new Defense("0", "0", "0"));
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---
        
        [Fact]
        public void CreateItem_WithBellowZeroParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera você das amarras do destino", new Attack("-30", "0"), new Defense("0", "0", "0"));
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithAboveLimitsParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera você das amarras do destino", new Attack("180", "00"), new Defense("0", "0", "0"));
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithNoConvertibleParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera você das amarras do destino", new Attack("adsdasd", "00"), new Defense("0", "0", "0"));
            action.Should().Throw<LeagueStore.Domain.Validation.DomainValidation>();
        }

    }
}
