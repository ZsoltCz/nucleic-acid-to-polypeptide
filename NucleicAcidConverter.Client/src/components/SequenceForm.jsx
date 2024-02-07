import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";

const readingFrames = [0, 1, 2];

export default function SequenceForm() {
  return (
    <form>
      <FormControl>
        <TextField
          label="DNA or RNA sequence"
          id="nucleotide-sequence"
          required
          multiline
          rows="4"
        />
      </FormControl>
      <FormControl>
        <InputLabel htmlFor="reading-frame">Reading frame</InputLabel>
        <Select>
          {readingFrames.map((readingFrame) => (
            <MenuItem value={readingFrame}>{readingFrame + 1}</MenuItem>
          ))}
        </Select>
      </FormControl>
      <FormControl>
        <Button variant="outlined">
          Translate
        </Button>
      </FormControl>
    </form>
  );
}
