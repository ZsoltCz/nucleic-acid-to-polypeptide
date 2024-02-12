import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import { useState } from "react";

const readingFrames = [0, 1, 2];

export default function SequenceForm({ setTranslationResult, displayedProperty, setDisplayedProperty }) {

  const [sequence, setSequence] = useState({
    nucleotideSequence: "",
    readingFrame: 0
  });

  const handleSequenceChange = (event) => {
    setSequence(prevSequence => {
      return {
        ...prevSequence,
        [event.target.name]: event.target.value
      };
    });
  };

  const formStyleTemp = {
    marginTop: "20px"
  }

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await fetch(`http://localhost:5007/translate?NucleotideSequence=${sequence.nucleotideSequence}&ReadingFrame=${sequence.readingFrame}`);
      if (!response.ok) {
        setTranslationResult([]);
        const message = await response.text();
        throw new Error(message);
      }
      const aminoAcids = await response.json();
      setTranslationResult(aminoAcids);
    } catch (error) {
      console.error(error);
    };
  };

  return (
    <form style={formStyleTemp} onSubmit={handleSubmit}>
      <FormControl>
        <TextField
          label="DNA or RNA sequence"
          id="nucleotide-sequence"
          required
          multiline
          rows="4"
          name="nucleotideSequence"
          onChange={handleSequenceChange}
          value={sequence.nucleotideSequence}
        />
      </FormControl>
      <FormControl>
        <InputLabel id="reading-frame-label">Reading frame</InputLabel>
        <Select
          labelId="reading-frame-label"
          value={sequence.readingFrame}
          label="Reading frame"
          name="readingFrame"
          onChange={handleSequenceChange}
        >
          {readingFrames.map((readingFrame) => (
            <MenuItem key={readingFrame} value={readingFrame}>
              {readingFrame + 1}
            </MenuItem>
          ))}
        </Select>
      </FormControl>
      <FormControl>
        <InputLabel id="displayed-property-label">
          Amino acid display
        </InputLabel>
        <Select value={displayedProperty} labelId="displayed-property-label">
          <MenuItem value="name">Name</MenuItem>
          <MenuItem value="threeLetterSymbol">Three letter symbol</MenuItem>
          <MenuItem value="oneLetterSymbol">One letter symbol</MenuItem>
        </Select>
      </FormControl>
      <FormControl>
        <Button type="submit" variant="outlined">
          Translate
        </Button>
      </FormControl>
    </form>
  );
};
