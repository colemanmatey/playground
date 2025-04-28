function Button({name, style, clickHandler}) {

    return (
        <button className={style} onClick={clickHandler}>{ name }</button>
    )
}

export default Button;
