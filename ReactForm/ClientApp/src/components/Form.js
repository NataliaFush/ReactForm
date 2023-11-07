import React, {useState} from 'react';
import {useForm, Controller, set} from "react-hook-form";
import {userService} from "../services/user.service";

const Form = () => {
    const [isEmailValid, setIsEmailValid] = useState(false);
    const { setError, trigger, control, handleSubmit, getValues, register, formState: { errors } } = useForm();


    //const [file, setFile] = useState < File | undefined > ();



    const isEmailAvailable = async (email) => {
        console.log('send to backend ' + email)
        const {isSuccess, messages} = await userService.checkEmail(email);
        setIsEmailValid(isSuccess)
        return isSuccess || messages;
    };

    const checkEmail = async (email) =>{
        console.log('trigger ' + email)
        const check = await trigger('email');
       
    }

    const onSubmit = async (data) => {
        console.log(data)
        const newUser = await userService.create(data)
            .then(value => value)
            .catch (value=> {
                if (!!value?.response?.data?.errors){
                    for (const valueKey in value.response.data.errors) {
                        setError(valueKey.toLowerCase(), {
                            type: 'server',
                            message: value.response.data.errors[valueKey].join('\n')
                        })
                    }
                }
            }
            );
    }

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <div>
                <label>Name:</label>
                <div>
                    <input
                        {...register('name', {
                            required: 'Це поле обов\'язкове',
                        minLength: {
                        value: 2,
                    message: 'Ім\'я занадто кородке'
                        }
                    })}
                    placeholder={'Name'}
                    type={'text'}
                />
                    {errors.name && (<p>{errors.name.message}</p>)}
                </div>
            </div>

            <div>
                <label>Email:</label>
                <Controller
                    name="email"
                    control={control}
                    defaultValue=""
                    rules={
                        {
                            onChange: async (event) => await checkEmail(event.target.value),
                            required: 'Це поле обов\'язкове',
                            minLength: {
                                value: 3,
                                message: 'Назва занадто кородка',
                            },
                            pattern: {
                                value: /^\S+@\S+\.\S+$/,
                                message: 'Некоректна адреса електронної пошти',
                            },
                            validate: {
                                isAvailable: async (value) => {
                                    return await isEmailAvailable(value);
                                },
                            },
                        }
                    }
                    render={({field, fieldState}) => (
                        <div>
                            <input {...field} type="email" placeholder="Email"/>
                            {isEmailValid ? <p>{'true'}</p> : <p>{'false'}</p>}
                            {fieldState.error && (<p>{fieldState.error.message}</p>)}
                        </div>
                    )}
                />
            </div>

            <div>
                <label>Age:</label>
                <Controller
                    name="age"
                    control={control}
                    defaultValue=""
                    rules={{
                        required: 'Це поле обов\'язкове',
                        min: {
                            value: 14,
                            message: 'Мінімум 14 років',
                        },
                    }}
                    render={({field, fieldState}) => (
                        <div>
                            <input {...field} type="number" placeholder="Age"/>
                            {fieldState.error && (<p>{fieldState.error.message}</p>)}
                        </div>
                    )}
                />
            </div>

            <div>
                <label>Password:</label>
                <Controller
                    name="password"
                    control={control}
                    defaultValue=""
                    rules={{
                        required: 'Це поле обов\'язкове',
                        pattern: {
                            value: /^(?=.*[A-Z])(?=.*\d).{8,}$/,
                            message: 'Пароль повинен містити великі літери і цифри',
                        }
                    }}
                    render={({field, fieldState}) => (
                        <div>
                            <input {...field} type="password" placeholder="Password"/>
                            {fieldState.error && (
                                <p>{fieldState.error.message}</p>
                            )}
                        </div>
                    )}
                />
            </div>

            <div>
                <label>Confirm Password:</label>
                <Controller
                    name="confirmPassword"
                    control={control}
                    defaultValue=""
                    rules={{
                        required: 'Це поле обов\'язкове',
                        validate: (value) => value === getValues('password') || 'Паролі не співпадають',
                    }}
                    render={({field, fieldState}) => (
                        <div>
                            <input {...field} type="password" placeholder="Confirm Password"/>
                            {fieldState.error && (
                                <p>{fieldState.error.message}</p>
                            )}
                        </div>
                    )}
                />
            </div>
            <div><input id="image" type="file" name="image" /></div>
            

            <button type="submit">Зареєструватися</button>
        </form>
    );
}

export default Form;