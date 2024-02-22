using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class AminoAcidProviderServiceTest
{
    private IAminoAcidProviderService _aminoAcidProviderService;

    private static readonly object[] TestCases =
    {
        new object[] { "UUU", "Phe" },
        new object[] { "UUC", "Phe" },

        new object[] { "UUA", "Leu" },
        new object[] { "UUG", "Leu" },
        new object[] { "CUU", "Leu" },
        new object[] { "CUC", "Leu" },
        new object[] { "CUA", "Leu" },
        new object[] { "CUG", "Leu" },

        new object[] { "AUU", "Ile" },
        new object[] { "AUC", "Ile" },
        new object[] { "AUA", "Ile" },

        new object[] { "AUG", "Met" },

        new object[] { "GUU", "Val" },
        new object[] { "GUC", "Val" },
        new object[] { "GUA", "Val" },
        new object[] { "GUG", "Val" },

        new object[] { "UCU", "Ser" },
        new object[] { "UCC", "Ser" },
        new object[] { "UCA", "Ser" },
        new object[] { "UCG", "Ser" },
        new object[] { "AGU", "Ser" },
        new object[] { "AGC", "Ser" },

        new object[] { "CCU", "Pro" },
        new object[] { "CCC", "Pro" },
        new object[] { "CCA", "Pro" },
        new object[] { "CCG", "Pro" },

        new object[] { "ACU", "Thr" },
        new object[] { "ACC", "Thr" },
        new object[] { "ACA", "Thr" },
        new object[] { "ACG", "Thr" },

        new object[] { "GCU", "Ala" },
        new object[] { "GCC", "Ala" },
        new object[] { "GCA", "Ala" },
        new object[] { "GCG", "Ala" },

        new object[] { "UAU", "Tyr" },
        new object[] { "UAC", "Tyr" },

        new object[] { "UAA", "Stop" },
        new object[] { "UAG", "Stop" },
        new object[] { "UGA", "Stop" },

        new object[] { "CAU", "His" },
        new object[] { "CAC", "His" },

        new object[] { "CAA", "Gln" },
        new object[] { "CAG", "Gln" },

        new object[] { "AAU", "Asn" },
        new object[] { "AAC", "Asn" },

        new object[] { "AAA", "Lys" },
        new object[] { "AAG", "Lys" },

        new object[] { "GAU", "Asp" },
        new object[] { "GAC", "Asp" },

        new object[] { "GAA", "Glu" },
        new object[] { "GAG", "Glu" },

        new object[] { "UGU", "Cys" },
        new object[] { "UGC", "Cys" },

        new object[] { "UGG", "Trp" },

        new object[] { "CGU", "Arg" },
        new object[] { "CGC", "Arg" },
        new object[] { "CGA", "Arg" },
        new object[] { "CGG", "Arg" },
        new object[] { "AGA", "Arg" },
        new object[] { "AGG", "Arg" },

        new object[] { "GGU", "Gly" },
        new object[] { "GGC", "Gly" },
        new object[] { "GGA", "Gly" },
        new object[] { "GGG", "Gly" }
    };

    [OneTimeSetUp]
    public void Init()
    {
        _aminoAcidProviderService = new AminoAcidProviderService();
    }

    [TestCaseSource(nameof(TestCases))]
    public void GetsCorrectAminoAcid(string codon, string expectedResult)
    {
        var actual = _aminoAcidProviderService.GetAminoAcid(codon).ThreeLetterSymbol;
        
        Assert.That(actual, Is.EqualTo(expectedResult));
    }
}