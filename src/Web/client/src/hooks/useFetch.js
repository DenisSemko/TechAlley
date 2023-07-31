import React from 'react'
import { useState, useEffect } from 'react';
import axios from 'axios';

const useFetch = (requestParams) => {
    
    const [data, setData] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);

    axios.defaults.baseURL = process.env.REACT_APP_BASE_URL;

    const fetchData = async (params) => {
        setIsLoading(true);
        try {
            const response = await axios.request({...params, withCredentials: true});
            setData(response.data);
        }
        catch (error) {
            setError(error);
        }
        finally {
            setIsLoading(false);
        }

    };

    useEffect(() => {
        fetchData(requestParams);
    }, [requestParams.url]);

    return { data, isLoading, error };
}

export default useFetch;