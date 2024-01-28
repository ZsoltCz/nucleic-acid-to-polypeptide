using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class AminoAcidProviderServiceTest
{
    private IAminoAcidProviderService _aminoAcidProviderService;

    private static readonly object[] TestCases =
    {
        
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