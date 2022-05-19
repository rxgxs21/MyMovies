<template>
<!--Okno startowe-->
    <div>
        <h3 class="d-flex justify-content-center">
            My Movies
        </h3>
        <h5 class="d-flex justify-content-center">
            Movie List Web Aplication
        </h5>
        <!--Przycisk do dodawanie filmów-->
        <div class="col-md-auto" align="center">
            <input type="button" class="btn btn-primary" @click="addClick" value="Add New Movie" />
        </div>
        <!--Tytuły kolumn w tabeli-->
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Release Date</th>
                    <th>Options</th>
                </tr>
            </thead>
            <!--Wypisanie danych filmów w osobnych wierszach oraz przycisków: edit, view, delete-->
            <tbody>
                <tr v-for="mov in movies" v-bind:key="mov.Id">
                    <td>{{ mov.Name }}</td>
                    <td>{{ mov.RealseDate}}</td>
                    <td>
                        <!--przycisk edit-->
                        <button type="button" class="btn btn-light mr-1"
                            @click="editClick(mov)" value="Edit Movie">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                class="bi bi-pencil" viewBox="0 0 16 16">
                                <path d="M12.146.146a.5.5 0 0 1 .708 0l3 3a.5.5 0 0 1 0 .708l-10 10a.5.5 0 0 1-.168.11l-5 2a.5.5 0 0 1-.65-.65l2-5a.5.5 0 0 1 .11-.168l10-10zM11.207 2.5 13.5 4.793 14.793 3.5 12.5 1.207 11.207 2.5zm1.586 3L10.5 3.207 4 9.707V10h.5a.5.5 0 0 1 .5.5v.5h.5a.5.5 0 0 1 .5.5v.5h.293l6.5-6.5zm-9.761 5.175-.106.106-1.528 3.821 3.821-1.528.106-.106A.5.5 0 0 1 5 12.5V12h-.5a.5.5 0 0 1-.5-.5V11h-.5a.5.5 0 0 1-.468-.325z" />
                            </svg>
                        </button>
                        <!--przycisk view-->
                        <button type="button" class="btn btn-light mr-1"
                            @click="showClick(mov)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                class="bi bi-aspect-ratio" viewBox="0 0 16 16">
                                <path d="M0 3.5A1.5 1.5 0 0 1 1.5 2h13A1.5 1.5 0 0 1 16 3.5v9a1.5 1.5 0 0 1-1.5 1.5h-13A1.5 1.5 0 0 1 0 12.5v-9zM1.5 3a.5.5 0 0 0-.5.5v9a.5.5 0 0 0 .5.5h13a.5.5 0 0 0 .5-.5v-9a.5.5 0 0 0-.5-.5h-13z" />
                                <path d="M2 4.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1H3v2.5a.5.5 0 0 1-1 0v-3zm12 7a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1 0-1H13V8.5a.5.5 0 0 1 1 0v3z" />
                            </svg>
                        </button>
                        <!--przycisk delete-->
                        <button type="button" class="btn btn-light mr-1" @click="deleteClick(mov)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                                class="bi bi-trash" viewBox="0 0 16 16">
                                <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z" />
                                <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z" />
                            </svg>
                        </button>
                    </td>
                </tr>
            </tbody>
        </table>
        <!--okno modalne-->
        <div v-if="myModel">
            <transition name="model">
                <div class="modal-mask">
                    <div class="modal-wrapper">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h4 class=" modal-title">{{ modalTitle }}</h4>
                                    <button type="button" class="btn-close" @click="myModel = false; showModel = false">
                                    </button>
                                </div>
                                <div class="modal-body">
                                    <div v-if="!showModel" class="label-group">
                                        <label>Title</label>
                                        <input type="text" class="form-control" v-model.trim="$v.Name.$model" :class="{
                                            'is-invalid': $v.Name.$error, 'is-valid': !$v.Name.$invalid
                                        }">
                                        <div class="valid-feedback">Your title is valid!</div>
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.Name.required">Title is required!</span>
                                            <span v-if="!$v.Name.maxLength">Title must have at most
                                                {{ $v.Name.$params.maxLength.max }} letters!</span>
                                        </div>
                                        <label>Realse Date</label>
                                        <input type="text" class="form-control" v-model.trim="$v.RealseDate.$model"
                                            :class="{
                                                'is-invalid': $v.RealseDate.$error, 'is-valid': !$v.RealseDate.$invalid
                                            }">
                                        <div class="valid-feedback"></div>
                                        <div class="invalid-feedback">
                                            <span v-if="!$v.RealseDate.between">Date must be between
                                                {{ $v.RealseDate.$params.between.min }} and
                                                {{ $v.RealseDate.$params.between.max }}!</span>
                                        </div>
                                        <input type="button" class="btn btn-primary" v-model="buttonMassege"
                                            @click="createClick" :disable="btnDisable" v-if="Id == null">
                                        <input type="button" class="btn btn-primary" v-model="buttonMassege"
                                            @click="updateClick" :disable="btnDisable" v-if="Id != null">
                                    </div>
                                    
                                    <div v-if="showModel" class="label-group mb-3">
                                        <div>
                                            <label>Title: {{ Name }}</label>
                                        </div>
                                        <div>
                                            <label>Realse Date: {{ RealseDate }}</label>
                                        </div>
                                        <div>
                                            <input type="button" class="btn btn-primary" v-model="buttonMassege"
                                                @click="closeShow">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </transition>
        </div>
    </div>
</template>

<script>
import { required, maxLength, between } from 'vuelidate/lib/validators'
import axios from 'axios'
import { variables } from './variables.js'
export default {
    name: 'MainPage',
    data() {
        return {
            Id: null, //globalne id filmu
            Name: "", //globalny tytuł filmu
            RealseDate: null, //globalna data wydania
            movies: [], //lista filmów
            modalTitle: "", //tytuł okna modalnego
            showModel: false, //wywołanie okna modalnego
            myModel: false, //tryb okna modalnego: false: add, edit/ true: view
            buttonMassege: "", //tytuł przycisku w oknie modalnym
            btnDisable: false //dezaktywacja przycisku
        }
    },

    //walidacje zgodne z bazą danych
    validations: {
        Name: {
            required,
            maxLength: maxLength(200)
        },
        RealseDate: {
            between: between(1900, 2100)
        }
    },

    mounted() {
        this.refreshData();
    },

    methods: {
        /**
         * Odświeża dane listy filmów.
         */
        refreshData() {
            axios.get(variables.API_URL)
                .then((response) => {
                    this.movies = response.data;
                });
        },

        /**
         * Otwiera okno modalne w trybie: Add.
         */
        addClick() {
            this.Name = "";
            this.RealseDate = null;
            this.modalTitle = "Add New Movie";
            this.buttonMassege = "Add Movie";
            this.myModel = true;
            this.Id = null;
        },

        /**
         * Otwiera okno modalne w trybie: Edit.
         */
        editClick(mov) {
            this.modalTitle = "Edit Movie";
            this.Id = mov.Id;
            this.Name = mov.Name
            this.RealseDate = mov.RealseDate
            this.myModel = true;
            this.buttonMassege = "Edit Movie";
        },

        /**
         * Otwiera okno modalne w trybie: Show.
         */
        showClick(mov) {
            this.showModel = true;
            this.myModel = true;
            this.modalTitle = "View";
            this.Name = mov.Name,
            this.RealseDate = mov.RealseDate;
            this.Id = mov.Id;
            this.buttonMassege = "ok";
        },

        /**
         * Dodaje nowy film do bazy danych.
         */
        createClick() {
            this.$v.$touch();
            if (!this.$v.$invalid) {
                this.btnDisable = true;
                axios.post(variables.API_URL, {
                    Name: this.Name,
                    RealseDate: this.RealseDate
                })
                    .then(() => {
                        this.refreshData();
                        this.myModel = false;
                        this.btnDisable = false;
                    });
            }
        },

        /**
         * Edytuje dane filmu w bazie danych.
         */
        updateClick() {
            this.$v.$touch();
            if (!this.$v.$invalid) {
                this.btnDisable = true;
                axios.put(variables.API_URL, {
                    Id: this.Id,
                    Name: this.Name,
                    RealseDate: this.RealseDate
                })
                    .then(() => {
                        this.refreshData();
                        this.myModel = false;
                        this.btnDisable = true;
                    });
            }
        },

        /**
         * Usuwa film z bazy danych
         */
        deleteClick(mov) {
            if (!confirm("Are you sure you want to delete " + mov.Name + " from movie list?")) {
                return;
            }
            axios.delete(variables.API_URL + mov.Id)
                .then(() => this.refreshData());
        },

        /**
         * Zamyka okno modalne(Show).
         */
        closeShow() {
            this.showModel = false;
            this.myModel = false;
            this.modalTitle = "";
            this.Name = "",
            this.RealseDate = null;
            this.Id = null;
            this.buttonMassege = "";
        }
    }
}
</script>

<style scoped>
.modal-mask {
    position: fixed;
    z-index: 9998;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background-color: rgba(0, 0, 0, .5);
    display: table;
    transition: opacity .3s ease;
}

.modal-wrapper {
    display: table-cell;
    vertical-align: middle;
}
</style>