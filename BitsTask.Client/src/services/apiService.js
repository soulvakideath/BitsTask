import axios from 'axios';

export const fetchCsvData = async () => {
  const response = await fetch("https://localhost:7219/api/csv/data");
  if (!response.ok) {
    throw new Error("Failed to fetch CSV data");
  }
  const data = await response.json();
  return data;
};

