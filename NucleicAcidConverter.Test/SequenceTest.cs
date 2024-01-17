using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class SequenceTest
{
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
}