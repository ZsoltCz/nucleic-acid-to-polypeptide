using NucleicAcidConverter.Model;
using NucleicAcidConverter.Service;

namespace NucleicAcidConverter.Test;

[TestFixture]
public class SequenceServiceTest
{
    private ISequenceService _sequenceService;
    
    private static readonly SequenceDto[] TestCases =
    {
        new SequenceDto("CTAAAGTATAATTAA"),
        new SequenceDto("CTAAAGTATAATTAA", 1),
        new SequenceDto("CTAAAGTATAATTAA", 2),
        new SequenceDto("GAAAAUAGCAUCCU", 0),
        new SequenceDto("GAAAAUAGCAUCCU", 1),
        new SequenceDto("GAAAAUAGCAUCCU", 2)
    };

    [OneTimeSetUp]
    public void Init()
    {
        _sequenceService = new SequenceService();
    }

    [TestCaseSource(nameof(TestCases))]
    public void CreatesCorrectSequence(SequenceDto sequenceDto)
    {
        var sequence = _sequenceService.CreateSequence(sequenceDto);
        
        Assert.Multiple(() =>
        {
            Assert.That(sequence.NucleotideSequence, Is.EqualTo(sequenceDto.NucleotideSequence));
            Assert.That(sequence.ReadingFrame, Is.EqualTo(sequenceDto.ReadingFrame));
        });
    }
}