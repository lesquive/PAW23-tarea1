import React, { useState, useEffect } from "react";
import axios from "axios";
import "./Restaurantes.css";
import { Link } from "react-router-dom";
import DeleteIcon from "@mui/icons-material/Delete";
import Grid from "@mui/material/Grid";

function Restaurantes() {
  const [restaurants, setRestaurants] = useState([]);

  const handleDelete = (restaurantId) => {
    axios
      .delete(`https://localhost:7059/api/restaurantes/${restaurantId}`)
      .then((response) => {
        setRestaurants((prevRestaurants) =>
          prevRestaurants.filter((restaurant) => restaurant.id !== restaurantId)
        );
      })
      .catch((error) => {
        console.error(error);
      });
  };

  useEffect(() => {
    axios
      .get("https://localhost:7059/api/restaurantes")
      .then((response) => {
        setRestaurants(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  }, []);

  return (
    <div className="restaurant-container">
      <h2>Restaurantes</h2>
      <Grid container direction="row" alignItems="center" spacing={2}>
        <Grid item xs={8}>
          <Link to="/agregar">
            <button className="btn">+ Agregar Restaurante</button>
          </Link>
        </Grid>
      </Grid>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Dueño</th>
            <th>Provincia</th>
            <th>Cantón</th>
            <th>Distrito</th>
            <th>Dirección Exacta</th>
            <th>Eliminar</th>
          </tr>
        </thead>
        <tbody>
          {restaurants.map((restaurant) => (
            <tr key={restaurant.id}>
              <td>
                <Link to={`/edit/${restaurant.id}`}>{restaurant.id}</Link>
              </td>
              <td>{restaurant.nombre}</td>
              <td>{restaurant.dueño}</td>
              <td>{restaurant.provincia}</td>
              <td>{restaurant.cantón}</td>
              <td>{restaurant.distrito}</td>
              <td>{restaurant.direcciónExacta}</td>
              <td>
                <button
                  className="delete-button"
                  onClick={() => handleDelete(restaurant.id)}
                >
                  <DeleteIcon />
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Restaurantes;
