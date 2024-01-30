using NucleicAcidConverter.Enums;
using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class SequenceTest
{
    private static readonly object[] EnumerationTestCases =
    {
        new object[] { "AATAATG", 0, new List<string> { "AAT", "AAT" } },
        new object[] { "AATAATG", 1, new List<string> { "ATA", "ATG" } },
        new object[] { "AATAATG", 2, new List<string> { "TAA" } }
    };
    
    private static readonly object[] TypeTestCases =
    {
        new object[] { "ATCATGAAGTTAGTAGTCAG", SequenceType.DNA },
        new object[] { "AUCGUCAAGUUACCGAUUGA", SequenceType.RNA },
        new object[] { "CGATCGATCGATCGATCGAT", SequenceType.DNA },
        new object[] { "UGAUGAUGAUGAUGAUGAU", SequenceType.RNA },
        new object[] { "ATGCTAGCTAGCTAGCTAGC", SequenceType.DNA },
        new object[] { "UAGCUAGCUAGCUAGCUAGC", SequenceType.RNA },
        new object[] { "CGCGCGCGCGCGCGCGCGCG", SequenceType.RNA },
        new object[] { "UAUAUAUAUAUAUAUAUAUA", SequenceType.RNA },
        new object[] { "ACGTACGTACGTACGTACGT", SequenceType.DNA },
        new object[] { "UGCAUGCAUGCAUGCAUGCA", SequenceType.RNA },
    };
    
    [TestCaseSource(nameof(EnumerationTestCases))]
    public void EnumeratesCorrectly(string nucleotideSequence, int readingFrame, List<string> expectedResult)
    {
        var sequence = new Sequence(nucleotideSequence, readingFrame);

        var actual = sequence.ToList();
        
        Assert.That(actual, Is.EqualTo(expectedResult));
    }

    [TestCaseSource(nameof(TypeTestCases))]
    public void AssignsTypeCorrectly(string nucleotideSequence, SequenceType expectedType)
    {
        var actual = new Sequence(nucleotideSequence, 0);
        
        Assert.That(actual.Type, Is.EqualTo(expectedType));
    }
}