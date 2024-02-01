using NucleicAcidConverter.Model;

namespace NucleicAcidConverter.Service;

public class SequenceService : ISequenceService
{
    public Sequence CreateSequence(SequenceDto sequenceDto)
    {
        return new Sequence(sequenceDto.NucleotideSequence, sequenceDto.ReadingFrame);
    }
}