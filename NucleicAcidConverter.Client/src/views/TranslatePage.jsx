import { useState } from "react";
import SequenceForm from "../components/SequenceForm";
import ResultDisplay from "../components/ResultDisplay";


export default function TranslatePage() {

  const [translationResult, setTranslationResult] = useState([]);

  return (
    <>
      <SequenceForm setTranslationResult={setTranslationResult} />
      <ResultDisplay translationResult={translationResult} />
    </>
  );
};