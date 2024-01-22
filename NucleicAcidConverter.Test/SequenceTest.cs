using NucleicAcidConverter.Enums;
using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class SequenceTest
{
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
    
    [Test]
    public void EnumeratesCorrectly()
    {
        var sequence = new Sequence("AATAATG", 1);

        var actual = sequence.ToList();
        var expected = new List<string>()
        {
            "ATA",
            "ATG"
        };
        
        Assert.That(actual, Is.EquivalentTo(expected));
    }

    [TestCaseSource(nameof(TypeTestCases))]
    public void AssignsTypeCorrectly(string nucleotideSequence, SequenceType expectedType)
    {
        var actual = new Sequence(nucleotideSequence, 0);
        
        Assert.That(actual.Type, Is.EqualTo(expectedType));
    }
}