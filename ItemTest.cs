using FluentAssertions;
using I_LeagueStore.Domain.Entities;
using System;
using Xunit;
using I_LeagueStore.Domain.ValueObjects;
using I_LeagueStore.Domain.Validation;

namespace LeagueStore.Domain.Tests
{
    public class ItemTest
    {
        [Fact]
        public void CreateItem_WithValideParameters_ResultValidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera voc� das amarras do destino", "120", new Attack("2", "30"), new Defense("10", "1", "13"));
            action.Should().NotThrow<DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithSpecialParameters_ResultInvalidState()
        {
            Action action = () => new Item("Ek@-de_Luden", "Um item poderoso que libera=voc�_das amarras do destino", "120", new Attack("2", "30"), new Defense("10", "1", "13"));
            action.Should().Throw<DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithEmptyParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera voc� das amarras do destino", "120", new Attack("0", ""), new Defense("0", "0", "0"));
            action.Should().Throw<DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithNullParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera voc� das amarras do destino", "120", new Attack("0", null), new Defense("0", "0", "0"));
            action.Should().Throw<DomainValidation>();
        }
        //---
        
        [Fact]
        public void CreateItem_WithBellowZeroParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera voc� das amarras do destino", "120", new Attack("-30", "0"), new Defense("0", "0", "0"));
            action.Should().Throw<DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithAboveLimitsParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera voc� das amarras do destino", "120", new Attack("180", "00"), new Defense("0", "0", "0"));
            action.Should().Throw<DomainValidation>();
        }
        //---

        [Fact]
        public void CreateItem_WithNoConvertibleParameters_ResultInvalidState()
        {
            Action action = () => new Item("Eko de Luden", "Um item poderoso que libera voc� das amarras do destino", "120", new Attack("adsdasd", "00"), new Defense("0", "0", "0"));
            action.Should().Throw<DomainValidation>();
        }
        //---

    }
}
