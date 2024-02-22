using NucleicAcidConverter.Model;
using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class TranslatorServiceTest
{
    private ITranslatorService _translatorService;

    private static readonly object[] TranslationTestCases =
    {
        new object[]
        {
            new Sequence("CTAAAGTATAATTAA", 0),
            new [] { "L", "K", "Y", "N", "*" }
        },
        new object[]
        {
            new Sequence("CTAAAGTATAATTAA", 1),
            new [] { "*", "S", "I", "I" }
        },
        new object[]
        {
            new Sequence("CTAAAGTATAATTAA", 2),
            new [] { "K", "V", "*", "L" }
        },
        new object[]
        {
        new Sequence("GAAAAUAGCAUCCU", 0),
        new [] { "E", "N", "S", "I" }
        },
        new object[]
        {
            new Sequence("GAAAAUAGCAUCCU", 1),
            new [] { "K", "I", "A", "S" }
        },
        new object[]
        {
            new Sequence("GAAAAUAGCAUCCU", 2),
            new [] { "K", "*", "H", "P" }
        }
    };

    [OneTimeSetUp]
    public void Init()
    {
        var aminoAcidProviderService = new AminoAcidProviderService();
        _translatorService = new TranslatorService(aminoAcidProviderService);
    }

    [TestCaseSource(nameof(TranslationTestCases))]
    public void TranslatesSequenceCorrectly(Sequence sequence, string[] expectedResult)
    {
        var actual = _translatorService.TranslateSequence(sequence).Select(aminoAcid => aminoAcid.OneLetterSymbol);
        
        Assert.That(actual, Is.EqualTo(expectedResult));
    }
}