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

export default function SequenceForm({ setTranslationResult }) {

  const [sequence, setSequence] = useState({
    nucleotideSequence: "",
    readingFrame: 0
  });

  const handleChange = (event) => {
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
          onChange={handleChange}
          value={sequence.nucleotideSequence}
        />
      </FormControl>
      <FormControl>
        <InputLabel htmlFor="reading-frame">Reading frame</InputLabel>
        <Select defaultValue={0} name="readingFrame" onChange={handleChange}>
          {readingFrames.map((readingFrame) => (
            <MenuItem key={readingFrame} value={readingFrame}>{readingFrame + 1}</MenuItem>
          ))}
        </Select>
      </FormControl>
      <FormControl>
        <Button type="submit" variant="outlined">
          Translate
        </Button>
      </FormControl>
    </form>
  );
}
