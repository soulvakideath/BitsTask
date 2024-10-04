import React, { useState, useEffect } from 'react';
import EnhancedTable from './components/EnhancedTable';
import { fetchCsvData } from './services/apiService';

const CsvTablePage = () => {
    const [data, setData] = useState([]);
  
    useEffect(() => {
      fetchCsvData()
        .then((response) => setData(response))
        .catch((error) => console.error('Error fetching data:', error));
    }, []);
  
    return (
      <div className="p-6">
        <EnhancedTable data={data} />
      </div>
    );
  };
  
  export default CsvTablePage;