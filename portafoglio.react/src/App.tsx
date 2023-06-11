import React from 'react';
import './App.css';
import { RouterProvider } from 'react-router-dom';
import router from './contextes/route.context';
import { AuthContext, useAuth } from './contextes/auth.context';

function App() {  
  return (
    <>
    <AuthContext.Provider value={useAuth()}>
      <RouterProvider router={router} />
    </AuthContext.Provider>
    </>    
  );
}

export default App;
