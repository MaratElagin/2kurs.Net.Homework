import React, {useState} from 'react'
import {Controller, SubmitHandler, useForm} from 'react-hook-form';
import axios from "axios";
import DatePicker from 'react-datepicker';
import 'react-datepicker/dist/react-datepicker.css'
import {FormInputs} from "../Dto/FormInputs";
import TextInput from "./inputs/textInput";
import {convictionOptions} from "./Selects/ConvictionOptions";
import {employmentOptions} from "./Selects/EmploymentOptions";
import {purposeOptions} from "./Selects/PurposeOptions";
import {depositOptions} from "./Selects/DepositOptions";
import {otherCreditOptions} from "./Selects/OtherCreditsOptions";
import {passportSeriesRegex, passportNumberRegex} from "../validationRegex/RegexValidation"
import TextAreaInput from "./inputs/textAreaInput";
import SelectInput from "./inputs/selectInput";

export default function CreditForm() {
    const {register, handleSubmit, formState: {errors}, reset, control} = useForm<FormInputs>({
        mode: "onChange"
    });
    
    const onSubmit = handleSubmit((data: FormInputs) => {
        console.log(JSON.stringify(data))
        let result = document.getElementsByClassName("result")[0];
        axios.post("credit/take", data)
            .then(r => result.innerHTML = r.data)
            .catch(r => console.log(r));
        reset();
    })

    return (
        <div>
        <div className={"d-flex justify-content-center"}>
            <form onSubmit={onSubmit} className="d-flex flex-column">
                <TextInput name="lastName" placeHolder="Фамилия"
                           register={register} errors={errors}
                           required="Введите фамилию"
                           maxLength={{
                               value: 30,
                               message: "Должно быть менее 30 символов"
                           }}/>
                <TextInput name="firstName" placeHolder="Имя"
                           register={register} errors={errors}
                           required="Введите имя"
                           maxLength={{
                               value: 30,
                               message: "Должно быть менее 30 символов"
                           }}/>
                <TextInput name="middleName" placeHolder="Отчество"
                           register={register} errors={errors}
                           required="Введите отчество"
                           maxLength={{
                               value: 30,
                               message: "Должно быть менее 30 символов"
                           }}/>
                <input className={"my_text_input"} type="number" placeholder="Возраст" min="21" max="72"
                       {...register("age", {
                           required: "Введите возраст (21-72)",
                       })}/>
                {errors?.age && <div style={{color: 'red'}}>{errors.age?.message}</div>}

                <SelectInput name="conviction" placeHolder="Сведения о судимости"
                             required="Заполните данные о судимости" control={control} options={convictionOptions}/>

                <h3 className={"mt-4 text-center"}>Паспортные данные</h3>
                <div className={"row"}>

                    <div className={"col-6"}>
                        <div className={"mb-4"}>
                            <TextInput name="passportSeries" placeHolder="Серия паспорта"
                                       register={register} errors={errors}
                                       required="Введите серию паспорта (4 цифры)"
                                       pattern={{
                                           value: passportSeriesRegex,
                                           message: "Введите корректные данные"
                                       }}
                            />
                        </div>
                        <div className={"mb-4"}>
                            <TextInput name="passportNumber" placeHolder="Номер паспорта"
                                       register={register} errors={errors}
                                       required="Введите номер паспорта (6 цифр)"
                                       pattern={{
                                           value: passportNumberRegex,
                                           message: "Введите корректные данные"
                                       }}
                            />
                        </div>
                        <div className={"w-100"}>
                            <Controller
                                name="passportDate"
                                control={control}
                                defaultValue={undefined}
                                rules={{
                                    required: "Введите дату выдачи"
                                }}
                                render={({field, fieldState: {error}}) => (
                                    <>
                                        <DatePicker onChange={(e) => field.onChange(e)}
                                                    selected={field.value}
                                                    placeholderText="Дата выдачи:"
                                                    className={"my_text_input w-100"}
                                        />
                                        {error && <div style={{color: 'red'}}>{error.message}</div>}
                                    </>
                                )}/>
                        </div>
                    </div>

                    <div className={"col-6"}>
                        <TextAreaInput name="passportAddress" placeHolder="Адрес прописки"
                                       register={register} errors={errors}
                                       required="Введите информацию о прописке"
                        />

                        <TextAreaInput name="passportAgency" placeHolder="Кем выдан"
                                       register={register} errors={errors}
                                       required="Введите название учреждения"
                        />
                    </div>
                </div>

                <h3 className={"mt-4 text-center"}>Кредит</h3>

                <input className={"my_text_input mb-2"} type="number" placeholder="Сумма кредита" min="0" max="10000000"
                       {...register("creditSum", {
                           required: "Введите сумму кредита (0-10000000)",
                       })}/>
                {errors?.age && <div style={{color: 'red'}}>{errors.age?.message}</div>}

                <SelectInput name="employment" placeHolder="Трудоустройство"
                             required="Выберите трудоустройство" control={control}
                             options={employmentOptions}/>
                
                <SelectInput name="purpose" placeHolder="Цель кредита"
                             required="Выберите цель кредитования" control={control} options={purposeOptions}/>

                <SelectInput name="deposit" placeHolder="Залог"
                             required="Выберите вид залога" control={control} options={depositOptions}/>
                
                <input className={"my_text_input mb-2"} type="number" placeholder="Возраст автомобиля (возможно, будет учтён)" min="0" max="100"
                       {...register("carAge", {
                           required: "Введите возраст автомобиля (0-100)",
                       })}/>
                {errors?.age && <div style={{color: 'red'}}>{errors.age?.message}</div>}
                
                <SelectInput name="otherCredits" placeHolder="Другие кредиты"
                             required="Выберите информацию о других кредитах" control={control}
                             options={otherCreditOptions}/>

                <div className={"d-flex justify-content-center"}>
                    <button className={"btn-primary border-0 mt-2 btn-send"} type="submit">Отправить</button>
                </div>
            </form>
        </div>
            <p className={"result text-center text-success mt-2"}></p>
        </div>
    );
}